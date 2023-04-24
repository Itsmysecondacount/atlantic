import "bootstrap/dist/css/bootstrap.min.css"
import { useEffect, useState } from "react";

const App = () => {

    //1.- Crear useState

    const [categorias, setCategorias] = useState([]);

    const [productos, setProductos] = useState([]);

    const [codcat, setCodcat] = useState("");

    const [nompro, setNompro] = useState("");

    const [precio, setPrecio] = useState("");

    //2.- Metodo Obtener
    const datosBD = async () => {
        
        const response = await fetch("api/categorium/Lista");
        
        if (response.ok) {
            const data = await response.json();
            console.log(data)
            setCategorias(data)
        } else {
            console.log("status code:" + response.status)
        }

        const response2 = await fetch("api/producto/Lista");
        
        if (response2.ok) {
            const data = await response2.json();
            console.log(data)
            setProductos(data)
        } else {
            console.log("status code:" + response2.status)
        }
        
    }

    // Despues de insertar datos
    useEffect(() => {
      console.log("productos, categorías")
        datosBD();
    },[])


    //8.- Guardar NOTA
    const guardarProducto = async (e) => {

        e.preventDefault()

        const response = await fetch("api/producto/Guardar", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
              nompro: "Nombasdre del producto",
              precio: 10.99,
              codcat: 2
            })
        })  

        if (response.ok) {
            setCodcat("");
            setNompro("");
            setPrecio("");
            await datosBD();
        }
    }

    //10 Cerrar Tarea
    const eliminarProducto = async (id) => {

        const response = await fetch("api/producto/Eliminar/" + id, {
            method:"DELETE"
        })

        if (response.ok)
            await datosBD();
    }

    return (
      <div className="container bg-dark p-4 vh-100">

      {/*Formulario*/}
      <h2 className="text-white">Lista de tareas</h2>
      <div className="row">

          <div className="col-sm-12">
              {/*9.- Crear Formulario*/}
              <form onSubmit={guardarProducto}> {/*   <form></form>   */}

                  <div className="input-group"> {/*  <div class="input-group"></div>    */}
                      <input type="text" className="form-control"
                          placeholder="Ingrese nombre del producto"
                          value={nompro}
                          onChange={(e) => setNompro(e.target.value)} />
                      
                      <input type="text" className="form-control"
                          placeholder="Ingrese el precio del producto"
                          value={precio}
                          onChange={(e) => setPrecio(e.target.value)} />

                      <input type="text" className="form-control"
                          placeholder="Ingrese el código de la categoría"
                          value={codcat}
                          onChange={(e) => setCodcat(e.target.value)} />

                      <button className="btn btn-success">Agregar</button>
                  </div>

              </form>
          </div>
         
      </div>


      {/*Lista*/}
      
      <div className="row mt-4">
          <div className="col-sm-12">
          
              {/*6.- Listar Productos*/}
              <div className="list-group">  
                  {
                      productos.map(
                          (item) => (
                              <div key={item.copro} className="list-group-item list-group-item-action">{/*  <div className="list-group-item list-group-item-action"></div>  */}

                                  <h5 className="text-primary">Código de producto: {item.copro}</h5>
                                  <h5 className="text-primary">Nombre de producto: {item.nompro}</h5>
                                  <h5 className="text-primary">Precio de producto: {item.precio}</h5>
                                  <h5 className="text-primary">Categoria de producto: {item.codcat}</h5>

                                  <div className="d-flex justify-content-between">    {/*   <div class="d-flex justify-content-between">    */}
                                      <button type="button" className="btn btn-sm btn-outline-danger"
                                          /*11.- Cerrar Tarea*/
                                          onClick={() => eliminarProducto(item.copro)}>
                                          Eliminar
                                      </button>
                                  </div>
                              
                              </div>
                          )
                      )
                  }
              </div>
          </div>
              
      </div>
  </div>
    )
}

export default App;