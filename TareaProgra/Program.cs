using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TareaProgra.Comunicacion;

namespace TareaProgra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine(puerto);
            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);

            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                //Servidor conecta a internet
                Console.WriteLine("Sevidor iniciado");
                while (true)
                {
                    Console.WriteLine("Esperando Cliente");
                    Socket socketCliente = servidor.ObtenerCliente();
                    ClienteCom cliente = new ClienteCom(socketCliente);
                    string mensaje;
                    string respuesta;
                    //Esperar Mensaje
                    int cont = 0;
                    while (cont == 0)
                    {
                        respuesta = cliente.Leer();
                    if (cliente.LeerMensajeCliente(respuesta))
                    {
                        cliente.Desconectar();
                        Console.WriteLine("El cliente dice: chao");
                        Console.WriteLine("Anotado en la libreta de cosas que no me importan");
                            cont = 1;
                        }
                    Console.WriteLine("El cliente dice: {0}", respuesta);
                    Console.WriteLine("Responder:");
                    mensaje = Console.ReadLine().Trim();
                    cliente.Escribir(mensaje);
                    if (cliente.LeerRespuestaServidor(mensaje)){                       {
                        cliente.Desconectar();
                        Console.WriteLine("El Servidor dice: chao");
                        Console.WriteLine("Anotado en la libreta de cosas que no me importan");
                                cont = 1;
                            }
                }
                }
                }
            }
            else
            {
                Console.WriteLine("Error, el puerto {0} esta en uso", puerto);
            }
        }
    }
}
    

