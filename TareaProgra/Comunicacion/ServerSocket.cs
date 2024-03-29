﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TareaProgra.Comunicacion
{
    internal class ServerSocket
    {
        private int puerto;
        private Socket servidor;

        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }

        public bool Iniciar()
        {
            try
            {
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //tomar posesion del puerto
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                //definir la cola de espera
                this.servidor.Listen(10);
                return true;
            }
            catch (SocketException ex)
            {

                return false;
            }
        }

        public Socket ObtenerCliente()
        {
            return this.servidor.Accept();
        }

        public void Cerrar()
        {
            try
            {
                this.servidor.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}

