using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using MC.Enterprise.Data;
using MC.ControlPedido.Datos;
using MC.ControlPedido.Model;

namespace MC.ControlPedido.Datos
{
    public class PedidoDAL: BaseML
    {
        //Cabecera de pedidos
        public string RegistrarPedido(DbTransaction oDbTransaction, In60pedido oIn60pedido) //Inserta Cabecera Pedidos 
        {
            string numeroPedido;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_InsertarIn60pedido");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60cencos", System.Data.DbType.String, oIn60pedido.In60cencos);
                _database.AddOutParameter(_command,"@In60numped", System.Data.DbType.String, 5);
                _database.AddInParameter(_command, "@In60codcli", System.Data.DbType.String, oIn60pedido.In60codcli);
                _database.AddInParameter(_command, "@In60fecha", System.Data.DbType.DateTime, oIn60pedido.In60fecha);
                _database.AddInParameter(_command, "@In60codres", System.Data.DbType.String, oIn60pedido.In60codres);
                _database.AddInParameter(_command, "@In60EspTec", System.Data.DbType.String, oIn60pedido.In60EspTec);
                _database.AddInParameter(_command, "@In60Obser", System.Data.DbType.String, oIn60pedido.In60Obser);
                _database.AddInParameter(_command, "@In60Estado", System.Data.DbType.String, oIn60pedido.In60Estado);
                _database.AddInParameter(_command, "@In60Aprobado", System.Data.DbType.Int16, oIn60pedido.In60Aprobado);
                _database.AddInParameter(_command, "@In60Expor", System.Data.DbType.String, oIn60pedido.In60Expor);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);
                _database.AddInParameter(_command, "@In60DestinoOrigen", System.Data.DbType.String, oIn60pedido.In60DestinoOrigen);
                _database.AddInParameter(_command, "@In60TipoPedido", System.Data.DbType.String, oIn60pedido.In60TipoPedido);
                _database.AddInParameter(_command, "@In60NameUser", System.Data.DbType.String, oIn60pedido.In60NameUser);
                _database.AddInParameter(_command, "@in60mm", System.Data.DbType.String, oIn60pedido.in60mm);
                _database.AddInParameter(_command, "@in60tipo", System.Data.DbType.String, oIn60pedido.in60tipo);
                _database.AddInParameter(_command, "@in60mmProv", System.Data.DbType.String, oIn60pedido.in60mmProv);
                _database.AddInParameter(_command, "@in60aaProv", System.Data.DbType.String, oIn60pedido.in60aaProv);

                _database.ExecuteNonQuery(_command, oDbTransaction);
                numeroPedido = _command.Parameters["@In60numped"].Value.ToString();

                return numeroPedido;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ActualizarPedido(DbTransaction oDbTransaction, In60pedido oIn60pedido)//Modifica Cabecera pedidos
        {
            string numeroPedido;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ModificarIn60pedido");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60cencos", System.Data.DbType.String, oIn60pedido.In60cencos);
                _database.AddOutParameter(_command, "@In60numped", System.Data.DbType.String, 5);
                _database.AddInParameter(_command, "@In60codcli", System.Data.DbType.String, oIn60pedido.In60codcli);
                _database.AddInParameter(_command, "@In60fecha", System.Data.DbType.DateTime, oIn60pedido.In60fecha);
                _database.AddInParameter(_command, "@In60codres", System.Data.DbType.String, oIn60pedido.In60codres);
                _database.AddInParameter(_command, "@In60EspTec", System.Data.DbType.String, oIn60pedido.In60EspTec);
                _database.AddInParameter(_command, "@In60Obser", System.Data.DbType.String, oIn60pedido.In60Obser);
                _database.AddInParameter(_command, "@In60Estado", System.Data.DbType.String, oIn60pedido.In60Estado);
                _database.AddInParameter(_command, "@In60Aprobado", System.Data.DbType.Int16, oIn60pedido.In60Aprobado);
                _database.AddInParameter(_command, "@In60Expor", System.Data.DbType.String, oIn60pedido.In60Expor);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);
                _database.AddInParameter(_command, "@In60DestinoOrigen", System.Data.DbType.String, oIn60pedido.In60DestinoOrigen);
                _database.AddInParameter(_command, "@In60TipoPedido", System.Data.DbType.String, oIn60pedido.In60TipoPedido);
                _database.AddInParameter(_command, "@In60NameUser", System.Data.DbType.String, oIn60pedido.In60NameUser);
                _database.AddInParameter(_command, "@in60mm", System.Data.DbType.String, oIn60pedido.in60mm);
                _database.AddInParameter(_command, "@in60tipo", System.Data.DbType.String, oIn60pedido.in60tipo);
                _database.AddInParameter(_command, "@in60mmProv", System.Data.DbType.String, oIn60pedido.in60mmProv);
                _database.AddInParameter(_command, "@in60aaProv", System.Data.DbType.String, oIn60pedido.in60aaProv);

                _database.ExecuteNonQuery(_command, oDbTransaction);
                numeroPedido = _command.Parameters["@In60numped"].Value.ToString();

                return numeroPedido;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void EliminarPedido(DbTransaction oDbTransaction, In60pedido oIn60pedido)//Modifica Cabecera y Detalle pedidos
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_EliminarIn60pedido");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60pedido.In60numped);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);

                _database.ExecuteNonQuery(_command, oDbTransaction);

            }
            catch (Exception ex)
            {
                
                throw ex;  
            }
        }
        public DataTable ListarPedido(In60pedido oIn60pedido) //Traer Cabecera de los Pedidos segun Area
        {
            _command = _database.GetStoredProcCommand("Usp_ControlPedido_Trae_PedxArea");
            try
            {                
                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@in60mm", System.Data.DbType.String, oIn60pedido.in60mm);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60pedido.In60numped);
                _database.AddInParameter(_command, "@In60TipoPedido", System.Data.DbType.String, oIn60pedido.In60TipoPedido);
                _database.AddInParameter(_command, "@in60nivelflujo", System.Data.DbType.Int64, oIn60pedido.in60nivelflujo);
                
                DataTable dt;
                dt = _database.ExecuteDataSet(_command).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        //Detalles de pedido
        public void RegistrarDetallePedido(DbTransaction oDbTransaction, In60detalle oIn60detalle)// Insertar Detalles 
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_InsertarIn60detalle");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60detalle.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60detalle.In60aa);
                _database.AddInParameter(_command, "@In60cencos", System.Data.DbType.String, oIn60detalle.In60cencos);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60detalle.In60numped);
                _database.AddInParameter(_command, "@In60codalm", System.Data.DbType.String, oIn60detalle.In60codalm);
                _database.AddInParameter(_command, "@In60codart", System.Data.DbType.String, oIn60detalle.In60codart);
                _database.AddInParameter(_command, "@In60Item", System.Data.DbType.Int16, oIn60detalle.In60Item);
                _database.AddInParameter(_command, "@In60Id", System.Data.DbType.Int16, 0);
                _database.AddInParameter(_command, "@In60desart", System.Data.DbType.String, oIn60detalle.In60desart);
                _database.AddInParameter(_command, "@In60unidad", System.Data.DbType.String, oIn60detalle.In60unidad);
                _database.AddInParameter(_command, "@In60cantidad", System.Data.DbType.Decimal, oIn60detalle.In60cantidad);
                _database.AddInParameter(_command, "@In60Estado", System.Data.DbType.String, oIn60detalle.In60Estado);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60detalle.In60Area);
                _database.AddInParameter(_command, "@In60NameUser", System.Data.DbType.String, oIn60detalle.In60NameUser);
                _database.AddInParameter(_command, "@In60NroParte", System.Data.DbType.String, oIn60detalle.In60NroParte);
                _database.AddInParameter(_command, "@In60Prioridad", System.Data.DbType.String, oIn60detalle.In60Prioridad);
                _database.AddInParameter(_command, "@In60Equipo", System.Data.DbType.String, oIn60detalle.In60Equipo);
                _database.AddInParameter(_command, "@in60mm", System.Data.DbType.String, oIn60detalle.in60mm);
                _database.AddInParameter(_command, "@In60Observacion", System.Data.DbType.String, oIn60detalle.In60Observacion);

                _database.ExecuteNonQuery(_command, oDbTransaction);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ActualizarDetallePedido(DbTransaction oDbTransaction, In60detalle oIn60detalle)// Modifica Detalles
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ModificarIn60detalle");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60detalle.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60detalle.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60detalle.In60numped);
                _database.AddInParameter(_command, "@In60Item", System.Data.DbType.Int16, oIn60detalle.In60Item);
                _database.AddInParameter(_command, "@In60unidad", System.Data.DbType.String, oIn60detalle.In60unidad);
                _database.AddInParameter(_command, "@In60cantidad", System.Data.DbType.Decimal, oIn60detalle.In60cantidad);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60detalle.In60Area);
                _database.AddInParameter(_command, "@In60NroParte", System.Data.DbType.String, oIn60detalle.In60NroParte);
                _database.AddInParameter(_command, "@In60Prioridad", System.Data.DbType.String, oIn60detalle.In60Prioridad);
                _database.AddInParameter(_command, "@In60Equipo", System.Data.DbType.String, oIn60detalle.In60Equipo);
                _database.AddInParameter(_command, "@In60Observacion", System.Data.DbType.String, oIn60detalle.In60Observacion);
                _database.AddInParameter(_command, "@In60desart", System.Data.DbType.String, oIn60detalle.In60desart);

                _database.ExecuteNonQuery(_command, oDbTransaction);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void EliminarDetallePedido(DbTransaction oDbTransaction, In60detalle oIn60detalle)// Elimina Detalles
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_EliminarIn60detalle");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60detalle.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60detalle.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60detalle.In60numped);
                _database.AddInParameter(_command, "@In60Item", System.Data.DbType.Int16, oIn60detalle.In60Item);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60detalle.In60Area);
   
                _database.ExecuteNonQuery(_command, oDbTransaction);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListarDetallePedido(In60pedido oIn60pedido)//Traer Detalle del Pedido
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ListarIn60detalle");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60pedido.In60numped);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);

                DataTable dt;
                dt = _database.ExecuteDataSet(_command).Tables[0];

                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Seguimiento de pedido
        public DataTable ListarCabeceraPedidoSeguimiento(In60detalleSeg oIn60detalleSeg, In60pedido oIn60pedido)//Traer los pedidos segun su area y su flujo de proceso
        {
            _command = _database.GetStoredProcCommand("Usp_ControlPedido_Trae_PedParaAprobar");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60detalleSeg.In60codemp);
                _database.AddInParameter(_command, "@in60FlujoProceso", System.Data.DbType.Int16, oIn60detalleSeg.in60FlujoProceso);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60detalleSeg.In60Area);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60detalleSeg.In60numped);
                _database.AddInParameter(_command, "@In60TipoPedido", System.Data.DbType.String, oIn60pedido.In60TipoPedido);
                
                DataTable dt;
                dt = _database.ExecuteDataSet(_command).Tables[0];

                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarDetallePedidoSeguimiento(In60detalleSeg oIn60detalleSeg)
        {
            _command = _database.GetStoredProcCommand("Usp_ControlPedido_Trae_PedParaAprobarDet");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60detalleSeg.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60detalleSeg.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60detalleSeg.In60numped);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60detalleSeg.In60Area);
                _database.AddInParameter(_command, "@in60FlujoProceso", System.Data.DbType.Int16, oIn60detalleSeg.in60FlujoProceso);

                DataTable dt;
                dt = _database.ExecuteDataSet(_command).Tables[0];

                return dt;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListarPedidoSeguimiento(In60pedido oIn60pedido)
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ListarIn60pedidoSeguimiento");
            try
            {
                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);
                _database.AddInParameter(_command, "@In60Aprobado", System.Data.DbType.Int16, oIn60pedido.In60Aprobado);

                DataTable dt;
                dt = _database.ExecuteDataSet(_command).Tables[0];
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable ListarReportePedidoSeguimiento(In60pedido oIn60pedido)
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_ReporteEstadoPedido");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60mm", System.Data.DbType.String, oIn60pedido.in60mm);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60pedido.In60numped);
                _database.AddInParameter(_command, "@In60TipoPedido", System.Data.DbType.String, oIn60pedido.In60TipoPedido);
                _database.AddInParameter(_command, "@in60nivelflujo", System.Data.DbType.Int16, oIn60pedido.in60nivelflujo);
                
                DataTable dt;
                dt = _database.ExecuteDataSet(_command).Tables[0];
                return dt;
                }
            catch (Exception)
            {
                throw;
            }
        }
        
        public string RegistrarPedidoSeguimiento(DbTransaction oDbTransaction, In60pedido oIn60pedido)
        {
            string numeroPedido;
            _command = _database.GetStoredProcCommand("usp_ControlPedido_InsertarIn60pedidoSeg");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60cencos", System.Data.DbType.String, oIn60pedido.In60cencos);
                _database.AddOutParameter(_command, "@In60numped", System.Data.DbType.String, 5);
                _database.AddInParameter(_command, "@In60codcli", System.Data.DbType.String, oIn60pedido.In60codcli);
                _database.AddInParameter(_command, "@In60fecha", System.Data.DbType.DateTime, oIn60pedido.In60fecha);
                _database.AddInParameter(_command, "@In60codres", System.Data.DbType.String, oIn60pedido.In60codres);
                _database.AddInParameter(_command, "@In60EspTec", System.Data.DbType.String, oIn60pedido.In60EspTec);
                _database.AddInParameter(_command, "@In60Obser", System.Data.DbType.String, oIn60pedido.In60Obser);
                _database.AddInParameter(_command, "@In60Estado", System.Data.DbType.String, oIn60pedido.In60Estado);
                _database.AddInParameter(_command, "@In60Aprobado", System.Data.DbType.Int16, oIn60pedido.In60Aprobado);
                _database.AddInParameter(_command, "@In60Expor", System.Data.DbType.String, oIn60pedido.In60Expor);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);
                _database.AddInParameter(_command, "@In60DestinoOrigen", System.Data.DbType.String, oIn60pedido.In60DestinoOrigen);
                _database.AddInParameter(_command, "@In60TipoPedido", System.Data.DbType.String, oIn60pedido.In60TipoPedido);
                _database.AddInParameter(_command, "@In60NameUser", System.Data.DbType.String, oIn60pedido.In60NameUser);
                _database.AddInParameter(_command, "@in60mm", System.Data.DbType.String, oIn60pedido.in60mm);
                _database.AddInParameter(_command, "@in60tipo", System.Data.DbType.String, oIn60pedido.in60tipo);
                _database.AddInParameter(_command, "@in60mmProv", System.Data.DbType.String, oIn60pedido.in60mmProv);
                _database.AddInParameter(_command, "@in60aaProv", System.Data.DbType.String, oIn60pedido.in60aaProv);

                _database.ExecuteNonQuery(_command, oDbTransaction);
                numeroPedido = _command.Parameters["@In60numped"].Value.ToString();

                return numeroPedido;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RegistrarDetallePedidoSeguimiento(DbTransaction oDbTransaction, In60detalleSeg oIn60detalleSeg)
        {
            _command = _database.GetStoredProcCommand("Usp_ControlPedido_Ins_In60detalleSeg");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60detalleSeg.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60detalleSeg.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60detalleSeg.In60numped);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60detalleSeg.In60Area);
                _database.AddInParameter(_command, "@In60Item", System.Data.DbType.Int16, oIn60detalleSeg.In60Item);

                _database.AddInParameter(_command, "@in60FlujoProceso", System.Data.DbType.Int16, oIn60detalleSeg.in60FlujoProceso);
                _database.AddInParameter(_command, "@In60EstadoAprob", System.Data.DbType.String, oIn60detalleSeg.In60EstadoAprob);
                _database.AddInParameter(_command, "@In60CantidadNueva", System.Data.DbType.Decimal, oIn60detalleSeg.In60CantidadNueva);
                _database.AddInParameter(_command, "@In60Observacion", System.Data.DbType.String, oIn60detalleSeg.In60Observacion);
                _database.AddInParameter(_command, "@in60flagultimoestado", System.Data.DbType.Int16, oIn60detalleSeg.in60flagultimoestado);
                _database.AddInParameter(_command, "@in60Cerrado", System.Data.DbType.Int16, oIn60detalleSeg.in60Cerrado);
                _database.AddInParameter(_command, "@in60UsuarioMod", System.Data.DbType.String, oIn60detalleSeg.@in60UsuarioMod);
                _database.AddInParameter(_command, "@in60FechaMod", System.Data.DbType.String, oIn60detalleSeg.in60FechaMod);
                _database.ExecuteNonQuery(_command, oDbTransaction);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void DeshacerAprobacion(DbTransaction oDbTransaction, In60detalleSeg oIn60detalleSeg)
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_DeshacerAprobacion");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60detalleSeg.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60detalleSeg.In60aa);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60detalleSeg.In60Area);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60detalleSeg.In60numped);
                _database.AddInParameter(_command, "@In60NroIntento", System.Data.DbType.Int16, oIn60detalleSeg.In60NroIntento);
                _database.AddInParameter(_command, "@in60FlujoProceso", System.Data.DbType.Int16, oIn60detalleSeg.in60FlujoProceso);
                _database.ExecuteNonQuery(_command, oDbTransaction);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void EliminarDetallesPedido(DbTransaction oDbTransaction, In60pedido oIn60pedido)
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_EliminarIn60detalles");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60pedido.In60numped);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);

                _database.ExecuteNonQuery(_command, oDbTransaction);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ObtenerCorreoJefeArea(In60pedido oIn60pedido, int idPerfil, ref string nombreJefeArea, ref string correo)
        {
            _command = _database.GetStoredProcCommand("usp_ControlPedido_Obtener_Correo");
            try
            {

                _database.AddInParameter(_command, "@In60codemp", System.Data.DbType.String, oIn60pedido.In60codemp);
                _database.AddInParameter(_command, "@In60aa", System.Data.DbType.String, oIn60pedido.In60aa);
                _database.AddInParameter(_command, "@In60numped", System.Data.DbType.String, oIn60pedido.In60numped);
                _database.AddInParameter(_command, "@In60Area", System.Data.DbType.String, oIn60pedido.In60Area);
                _database.AddInParameter(_command, "@In60codres", System.Data.DbType.String, oIn60pedido.In60codres);
                _database.AddInParameter(_command, "@IdPerfil", System.Data.DbType.Int16, idPerfil);

                DataTable dt;
                dt = _database.ExecuteDataSet(_command).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    nombreJefeArea = Convert.ToString(dt.Rows[0]["Nombre"]);
                    correo = Convert.ToString(dt.Rows[0]["in23Correo"]);
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
