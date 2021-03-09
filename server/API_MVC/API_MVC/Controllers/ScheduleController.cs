using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API_MVC.Controllers
{
    public class ScheduleController : Controller
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
        public JsonResult Incluir(ScheduleModel model)
        {
            BoSchedule bo = new BoSchedule();
            
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
                
                model.Id = bo.Incluir(new Schedule()
                {                    
                    WeekDay = model.WeekDay,
                    Hour_Begin = model.Hour_Begin,
                    Hour_End = model.Hour_End,
                    DoctorId = model.DoctorId
                });

           
                return Json("Cadastro efetuado com sucesso");
            }
        }

        [HttpPost]
        public JsonResult Alterar(ScheduleModel model)
        {
            BoSchedule bo = new BoSchedule();
       
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
                bo.Alterar(new Schedule()
                {
                    WeekDay = model.WeekDay,
                    Hour_Begin = model.Hour_Begin,
                    Hour_End = model.Hour_End,
                    DoctorId = model.DoctorId
                });
                               
                return Json("Cadastro alterado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {
            BoSchedule bo = new BoSchedule();
            Schedule schedule = bo.Consultar(id);
            Models.ScheduleModel model = null;

            if (schedule != null)
            {
                model = new ScheduleModel()
                {
                    WeekDay = model.WeekDay,
                    Hour_Begin = model.Hour_Begin,
                    Hour_End = model.Hour_End,
                    DoctorId = model.DoctorId
                };   
            }

            return View(model);
        }

       [HttpDelete]
        public JsonResult Deletar(ScheduleModel model)
        {
            BoSchedule bo = new BoSchedule();
       
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
                    WeekDay = model.WeekDay,
                    Hour_Begin = model.Hour_Begin,
                    Hour_End = model.Hour_End,
                    DoctorId = model.DoctorId
                });
                               
                return Json("Cadastro deletado com sucesso");
            }
        }

    }
}