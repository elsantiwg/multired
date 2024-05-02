using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Multired.BLL.Interfaces;
using Firebase.Storage;
using Firebase.Auth;
using SistemaVenta.Entity;
using Multired.DAL.Interfaces;


namespace Multired.BLL.Implementacion
{
    public class FireBaseService : IFireBaseService
    {
        private readonly IGerenericRepository<Configuracion> _repositorio;

        //constructor
        public FireBaseService(IGerenericRepository<Configuracion> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<string> SubirStorage(Stream StreamArchivo, string CarpetaDestino, string NombreArchivo)
        {
            String UrlImagen = "";
            try {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));

                Dictionary<String, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                //crear autorizacion
                //proveedor
                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));
                //crear un correo y contraseña
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"], Config["clave"]);

                //crear token de cancelacion
                var cancellation = new CancellationTokenSource();

                //crear una tarea para ehecutar el servicio de firebase storage
                /* al subir una imagen se creara una url para acceder a esta imagen o archivo
                 */
                var task = new FirebaseStorage(
                    Config["ruta"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    //configuracion
                    .Child(Config[CarpetaDestino])
                    .Child(NombreArchivo)
                    .PutAsync(StreamArchivo, cancellation.Token);

                UrlImagen = await task;
            }
            catch{
                UrlImagen = "";
            
            }
            return UrlImagen;
        }
        public async Task<bool> EliminarStorage(string CarpetaDestino, string NombreArchivo)
        {
            try
            {
                IQueryable<Configuracion> query = await _repositorio.Consultar(c => c.Recurso.Equals("FireBase_Storage"));

                Dictionary<String, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

                //crear autorizacion
                //proveedor
                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));
                //crear un correo y contraseña
                var a = await auth.SignInWithEmailAndPasswordAsync(Config["email"], Config["clave"]);

                //crear token de cancelacion
                var cancellation = new CancellationTokenSource();

                //crear una tarea para ehecutar el servicio de firebase storage
                /* al subir una imagen se creara una url para acceder a esta imagen o archivo
                 */
                var task = new FirebaseStorage(
                    Config["ruta"],
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    //configuracion
                    .Child(Config[CarpetaDestino])
                    .Child(NombreArchivo)
                    .DeleteAsync();
                await task;

                return true;
            }
            catch
            {
                return  false;

            }
        }

    }
}
