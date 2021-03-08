using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI2.Controllers
{
    public class DoctorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(DoctorModel model)
        {
            BoDoctor bo = new BoDoctor();
            
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                
                model.Id = bo.Incluir(new Doctor()
                {                    
                    Name = model.Name,
                    CRM = model.CRM,
                    Specialty = model.Specialty
                });

                return Json("Cadastro efetuado com sucesso");
            }
        }

        [HttpPut]
        public JsonResult Alterar(DoctorModel model)
        {
            BoDoctor bo = new BoDoctor();
            Doctor doctor = bo.Consultar(id);
            Models.DoctorModel model = null;
       
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bo.Alterar(new Doctor()
                {                    
                    Name = model.Name,
                    CRM = model.CRM,
                    Specialty = model.Specialty
                });
                               
                return Json("Cadastro alterado com sucesso");
            }
        }

       [HttpDelete]
        public JsonResult Deletar(DoctorModel model)
        {
            BoDoctor bo = new BoDoctor();
       
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                bo.Deletar(new Doctor()
                {                    
                    Name = model.Name,
                    CRM = model.CRM,
                    Specialty = model.Specialty
                });
                               
                return Json("Cadastro deletado com sucesso");
            }
        }

    }
}