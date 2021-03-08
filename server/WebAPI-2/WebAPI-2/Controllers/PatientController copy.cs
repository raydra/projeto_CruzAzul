using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI2.Controllers
{
    public class PatientController : Controller
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
        public JsonResult Incluir(PatientModel model)
        {
            BoPatient bo = new BoPatient();
            
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
                
                model.Id = bo.Incluir(new Patient()
                {                    
                    Name = model.Name,
                    CPF = model.CPF,
                    Email = model.Email,
                    Whatsapp = model.Whatsapp
                });

                return Json("Cadastro efetuado com sucesso");
            }
        }

        [HttpPut]
        public JsonResult Alterar(PatientModel model)
        {
            BoPatient bo = new BoPatient();
            Patient patient = bo.Consultar(id);
            Models.PatientModel model = null;
       
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
                bo.Alterar(new Patient()
                {                    
                    Name = model.Name,
                    CPF = model.CPF,
                    Email = model.Email,
                    Whatsapp = model.Whatsapp
                });
                               
                return Json("Cadastro alterado com sucesso");
            }
        }

       [HttpDelete]
        public JsonResult Deletar(PatientModel model)
        {
            BoPatient bo = new BoPatient();
       
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
                bo.Deletar(new Patient()
                {                    
                    Name = model.Name,
                    CPF = model.CPF,
                    Email = model.Email,
                    Whatsapp = model.Whatsapp
                });
                               
                return Json("Cadastro deletado com sucesso");
            }
        }

    }
}