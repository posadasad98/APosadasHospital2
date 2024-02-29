using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Hospital
    {
        public static Dictionary<string, object> GetAll()
        {
            ML.Hospital hosp = new ML.Hospital();
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { {"Hospital", hosp}, {"Exepcion", exepcion}, {"Resultado",false} };
            try
            {
                using(DL.AposadasHospital2Context context = new DL.AposadasHospital2Context())
                {
                    var registros = (from Hospital in context.Hospitals
                                     select new
                                     {
                                         IdHospital = Hospital.IdHospital,
                                         Nombre = Hospital.Nombre,
                                         Direccion = Hospital.Direccion,
                                         AniodeConstruccion = Hospital.AniodeConstruccion,
                                         IdEspecialidad = Hospital.IdEspecialidad
                                     }).ToList();
                    if(registros != null )
                    {
                        hosp.Hospitales = new List<object>();

                        foreach (var registro in registros)
                        {
                            ML.Hospital hospital = new ML.Hospital();

                            hospital.IdHospital = registro.IdHospital;
                            hospital.Nombre = registro.Nombre;
                            hospital.Direccion = registro.Direccion;
                            hospital.AniodeConstruccion = (DateTime)registro.AniodeConstruccion;

                            hospital.Especialidad = new ML.Especialidad();
                            hospital.Especialidad.IdEspecialidad = (int)registro.IdEspecialidad;

                            hosp.Hospitales.Add(hospital);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Hospital"] = hosp;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> Delete(int IdHospital)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { {"Hospital",IdHospital}, {"Exepcion", exepcion}, {"Resultado",false} };
            try
            {
                using (DL.AposadasHospital2Context context = new DL.AposadasHospital2Context())
                {
                    var filasAfectadas = context.Database.ExecuteSqlRaw($"DeleteHospital'{IdHospital}'");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }

    }
}
