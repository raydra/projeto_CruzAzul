using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.BLL
{
    public class BoPatient
    {
        public long Incluir(DML.Patient patient)
        {
            DAL.DaoPatient pat = new DAL.DaoPatient();
            return pat.Incluir(patient);
        }
        public void Alterar(DDML.Patient patient)
        {
            DAL.DaoPatient pat = new DAL.DaoPatient();
            pat.Alterar(patient);
        }
        public DML.Patient Consultar(long id)
        {
            DAL.DaoPatient pat = new DAL.DaoPatient();
            return pat.Consultar(id);
        }
        public void Excluir(long id)
        {
            DAL.DaoPatient pat = new DAL.DaoPatient();
            pat.Excluir(id);
        }
        public List<DML.Patient> Listar()
        {
            DAL.DaoPatient pat = new DAL.DaoPatient();
            return pat.Listar();
        }
        public List<DML.Patient> Pesquisa(int iniciarEm, int terminaEm, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoPatient pat = new DAL.DaoPatient();
            return pat.Pesquisa(iniciarEm,  terminaEm, campoOrdenacao, crescente, out qtd);
        }
    }
}
