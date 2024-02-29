using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HospitalController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Hospital hospital = new ML.Hospital();
            Dictionary<string, object> result = BL.Hospital.GetAll();
            hospital = (ML.Hospital)result["Hospital"];
            return View(hospital);
        }

        [HttpGet]
        public ActionResult Delete(int IdHospital)
        {
            Dictionary<string,object> result = BL.Hospital.Delete(IdHospital);
            bool resultado = (bool)result["Resultado"];
            if(resultado == true)
            {
                ViewBag.Mensaje = "El hospital ha sido eliminado";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Mensaje = "El hospital no ha sido eliminado";
                return PartialView("Modal");
            }
        }

    }
}
