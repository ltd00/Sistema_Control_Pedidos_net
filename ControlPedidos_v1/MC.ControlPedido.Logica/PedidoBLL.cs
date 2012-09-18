using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Logica
{
    public class PedidoBLL
    {
        public DataTable ListarPedido(In60pedido oIn60pedido)
        {
            return new PedidoDAL().ListarPedido(oIn60pedido);
        }

        public DataTable ListarPedidoSeguimiento(In60pedido oIn60pedido)
        {
            return new PedidoDAL().ListarPedidoSeguimiento(oIn60pedido);
        }
        public DataTable ListarPedidoSeguimientoxarea(In60detalleSeg oIn60detalleSeg , In60pedido oIn60pedido)
        {
            return new PedidoDAL().ListarCabeceraPedidoSeguimiento(oIn60detalleSeg, oIn60pedido);
        }

        public DataTable ListarDetallePedido(In60pedido oIn60pedido)
        {
            return new PedidoDAL().ListarDetallePedido(oIn60pedido);
        }

        /// <summary>
        /// Registra la cabecera del pedido
        /// </summary>
        /// <param name="oIn60pedido"></param>
        /// <returns></returns>
        public string RegistrarPedido(In60pedido oIn60pedido, List<In60detalle> oIn60detalles)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                PedidoDAL oPedidoDAL = new PedidoDAL();
                string numeroPedido = oPedidoDAL.RegistrarPedido(objTransactionML.GetTransaction(), oIn60pedido);

                if (oIn60detalles != null)
                {
                    for (int i = 0; i < oIn60detalles.Count; i++)
                    {
                        oPedidoDAL.RegistrarDetallePedido(objTransactionML.GetTransaction(), oIn60detalles[i]);
                    }

                }
                oPedidoDAL.Dispose();
                oPedidoDAL = null;

                objTransactionML.CommitTransaction();

                return numeroPedido;
            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        /// <summary>
        /// Actualiza la cabecera del pedido
        /// </summary>
        /// <param name="oIn60pedido"></param>
        /// <returns></returns>
        public string ActualizarPedido(In60pedido oIn60pedido, List<In60detalle> oIn60detalles)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                PedidoDAL oPedidoDAL = new PedidoDAL();
                string numeroPedido = oPedidoDAL.ActualizarPedido(objTransactionML.GetTransaction(), oIn60pedido);


                //Eliminamos los detalles
                if (oIn60detalles != null)
                {
                    oPedidoDAL.EliminarDetallesPedido(objTransactionML.GetTransaction(), oIn60pedido);


                    for (int i = 0; i < oIn60detalles.Count; i++)
                    {
                        oPedidoDAL.RegistrarDetallePedido(objTransactionML.GetTransaction(), oIn60detalles[i]);
                    }
                }

                oPedidoDAL.Dispose();
                oPedidoDAL = null;

                objTransactionML.CommitTransaction();


                return numeroPedido;
            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        public void RegistrarDetallePedido(In60detalle oIn60detalle)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                new PedidoDAL().RegistrarDetallePedido(objTransactionML.GetTransaction(), oIn60detalle);

                objTransactionML.CommitTransaction();

            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        public void RegistrarDetallePedidoSeguimiento(In60detalleSeg oIn60detalleSeg)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                new PedidoDAL().RegistrarDetallePedidoSeguimiento(objTransactionML.GetTransaction(), oIn60detalleSeg);

                objTransactionML.CommitTransaction();

            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        public void ActualizarDetallePedido(In60pedido oIn60pedido, List<In60detalle> oIn60detalles)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                PedidoDAL oPedidoDAL = new PedidoDAL();

                oPedidoDAL.ActualizarPedido(objTransactionML.GetTransaction(), oIn60pedido);

                for (int i = 0; i < oIn60detalles.Count; i++)
                {
                    oPedidoDAL.ActualizarDetallePedido(objTransactionML.GetTransaction(), oIn60detalles[i]);
                }

                objTransactionML.CommitTransaction();

            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

       
        public DataTable ListarDetallePedidoSeguimiento(In60detalleSeg oIn60detalleSeg)
        {
            return new PedidoDAL().ListarDetallePedidoSeguimiento(oIn60detalleSeg);
        }

        public void EliminarDetallePedido(In60detalle oIn60detalle)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                new PedidoDAL().EliminarDetallePedido(objTransactionML.GetTransaction(), oIn60detalle);

                objTransactionML.CommitTransaction();

            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        public void EliminarPedido(In60pedido oIn60pedido)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                new PedidoDAL().EliminarPedido(objTransactionML.GetTransaction(), oIn60pedido);

                objTransactionML.CommitTransaction();

            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        

        public void RegistrarDetallePedidoSeguimientos(List<In60detalleSeg> oIn60detalleSegs)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                for (int i = 0; i < oIn60detalleSegs.Count; i++)
                {
                    new PedidoDAL().RegistrarDetallePedidoSeguimiento(objTransactionML.GetTransaction(), oIn60detalleSegs[i]);
                }

                objTransactionML.CommitTransaction();

            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        public void DeshacerAprobacion(In60detalleSeg oIn60DetalleSeg)
        {
            MC.Enterprise.Data.TransactionML objTransactionML = null;
            try
            {
                objTransactionML = new MC.Enterprise.Data.TransactionML();
                objTransactionML.BeginTransaction();

                new PedidoDAL().DeshacerAprobacion(objTransactionML.GetTransaction(), oIn60DetalleSeg);

                objTransactionML.CommitTransaction();

            }
            catch (Exception)
            {
                objTransactionML.RollbackTransaction();
                throw;
            }
            finally
            {
                if (objTransactionML != null) objTransactionML.Dispose();
                objTransactionML = null;
            }
        }

        public DataTable ListarReportePedidoSeguimiento(In60pedido oIn60pedido)
        {
            return new PedidoDAL().ListarReportePedidoSeguimiento(oIn60pedido);
        }

        public void ObtenerCorreoJefeArea(In60pedido oIn60pedido, int idPerfil, ref string nombreJefeArea, ref string correo)
        {
            new PedidoDAL().ObtenerCorreoJefeArea(oIn60pedido, idPerfil, ref nombreJefeArea, ref correo);
        }
    }
}
