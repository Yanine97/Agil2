using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agil
{
    class Global
    {
        public static string v_Rol = "";
        public static string v_Descriocion_Rol = "";
        public static string v_CodUsuario = "";
        public static string v_NombreUsuario = "";
        public static int v_CodUsuarioPermiso;
        public static string v_CodProyecto;
        public static string v_NombreProyecto;
        public static string v_CodBacklog;
        public static string v_CodSprint;
        public static string v_DescripcionSprint;

        public static string v_conexion = @"server=HP245-G5\SQLEXPRESS; database = Agil ; User Id=sa;Password=sa; ";
    }
}
