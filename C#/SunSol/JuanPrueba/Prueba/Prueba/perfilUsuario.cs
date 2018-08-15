using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba
{
    public class perfilUsuario
    {
        public int ClientesAgregar,
                   ClientesConsultar,
                   ClientesEditar,
                   ClientesEliminar,
                   CobranzasAgregar,
                   CobranzasConsultar,
                   CobranzasEditar,
                   CobranzasEliminar,
                   codigo,
                   Comisiones,
                   ContratoReportes,
                   ContratoAgregar,
                   ContratoConsultar,
                   ContratoEditar,
                   ContratoEliminar,
                   MantenimientoRespaldar,
                   MantenimientoTablas,
                   Reportes,
                   ReservacionesAgregar,
                   ReservacionesConsultar,
                   ReservacionesEditar,
                   ReservacionesEliminar,
                   TemporadasAgregar,
                   TemporadasConsultar,
                   TemporadasEditar,
                   TemporadasEliminar,
                   Perfiles,
                   Usuarios,
                   MantenimientoEmpleados,
                   MantenimientoCCVCON,
                   MantenimientoTiposContratos,
                   MantenimientoMigracion,
                   FormularioActualizarContratos,
                   MantenimientoManifiestos,
                   ReportesFinancieros,
                   ppf,
                   Reservaciones,
                   GerenteSalaAgregar,
                   GerenteSalaConsultar,
                   GerenteSalaEditar,
                   GerenteSalaEliminar,
                   CrearHos_Opc,
                   CrearLin_Clos,
                   ConceptosVisualizar,
                   ConceptosEliminar,
                   ConceptosEditar,
                   ConceptosInsertar,
                   RecibosCajaInsertar,
                   RecibosCajaModificar,
                   RecibosCajaEliminar,
                   RecibosCajaVisualizar,
                   reporte_codseg;
        public string Nombre;
        public conexionBD BD;

        public perfilUsuario()
        {

            this.ClientesAgregar=0;
            this.ClientesConsultar=0;
            this.ClientesEditar=0;
            this.ClientesEliminar=0;
            this.CobranzasAgregar = 0;
            this.CobranzasConsultar=0;
            this.CobranzasEditar=0;
            this.CobranzasEliminar=0;
            this.codigo=0;
            this.Comisiones=0;
            this.ContratoReportes=0;
            this.ContratoAgregar=0;
            this.ContratoConsultar=0;
            this.ContratoEditar=0;
            this.ContratoEliminar=0;
            this.MantenimientoRespaldar=0;
            this.MantenimientoTablas=0;
            this.Nombre="";
            this.Reportes=0;
            this.ReservacionesAgregar=0;
            this.ReservacionesConsultar=0;
            this.ReservacionesEditar=0;
            this.ReservacionesEliminar=0;
            this.TemporadasAgregar=0;
            this.TemporadasConsultar=0;
            this.TemporadasEditar=0;
            this.TemporadasEliminar=0;
            this.Perfiles=0;
            this.Usuarios=0;
            this.MantenimientoEmpleados=0;
            this.MantenimientoCCVCON=0;
            this.MantenimientoTiposContratos=0;
            this.MantenimientoMigracion=0;
            this.FormularioActualizarContratos=0;
            this.MantenimientoManifiestos=0;
            this.ReportesFinancieros=0;
            this.ppf=0;
            this.Reservaciones=0;
            this.GerenteSalaAgregar=0;
            this.GerenteSalaConsultar=0;
            this.GerenteSalaEditar=0;
            this.GerenteSalaEliminar=0;
            this.CrearHos_Opc=0;
            this.CrearLin_Clos=0;
            this.ConceptosVisualizar=0;
            this.ConceptosEliminar=0;
            this.ConceptosEditar=0;
            this.ConceptosInsertar=0;
            this.RecibosCajaInsertar=0;
            this.RecibosCajaModificar=0;
            this.RecibosCajaEliminar=0;
            this.RecibosCajaVisualizar=0;
            this.reporte_codseg=0;

            this.BD = new conexionBD(Prueba.Variables_Globales.datosconexion);
        }

    }
}
