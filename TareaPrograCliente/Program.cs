using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Configuration;
using TareaPrograCliente.Comunicacion;

namespace TareaPrograCliente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            string servidor = ConfigurationManager.AppSettings["servidor"];

            Console.ForegroundColor = ConsoleColor.Green;            
            Console.WriteLine("Conectando a servidor {0} en puerto {1}", servidor, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(servidor, puerto);
            if (clienteSocket.Conectar())
            {
                //CLIENTE
                Console.WriteLine("Conectado con el servidor...");
                string mensaje;
                string respuesta;
                int cont = 0;
                while (cont == 0) {
                    Console.WriteLine("Enviar Mensaje:");
                    mensaje = Console.ReadLine().Trim();
                    clienteSocket.Escribir(mensaje);
                    if (mensaje == "chao")
                    {
                        clienteSocket.Desconectar();
                        cont = 1;
                    }
                    Console.WriteLine("Esperando respuesta...");
                    respuesta = clienteSocket.Leer();
                    Console.WriteLine("R: {0}", respuesta);
                    if (respuesta == "chao")
                    {
                        clienteSocket.Desconectar();
                        Console.WriteLine("Al cabo que ni queria seguir hablando contigo");
                        cont = 1;
                    }
                }
                Console.WriteLine("Conexion terminada :C");

            }
            else
            {
                Console.WriteLine("Error de comunicacion...");
            }
            Console.ReadKey();
        }
    }
}

 