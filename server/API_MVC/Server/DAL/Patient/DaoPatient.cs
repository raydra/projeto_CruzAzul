using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.DML;

namespace Server.DAL
{
    /// <summary>
    /// Classe de acesso a dados de Pacientes
    /// </summary>
    internal class DaoPatient : AcessoDados
    {
        internal long Incluir(DML.Patient patient)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();
            
            parametros.Add(new System.Data.SqlClient.SqlParameter("Name", patient.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", patient.Sobrenome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Email", patient.Nacionalidade));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Whatsapp", patient.CEP));

            DataSet ds = base.Consultar("IncPatientV2", parametros);
            long ret = 0;
            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out ret);
            return ret;
        }
        internal DML.Patient Consultar(long Id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", Id));

            DataSet ds = base.Consultar("ConsPatient", parametros);
            List<DML.Patient> pat = Converter(ds);

            return pat.FirstOrDefault();
        }
        internal List<Patient> Pesquisa(int iniciarEm, int terminaEm, string campoOrdenacao, bool crescente, out int qtd)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("iniciarEm", iniciarEm));
            parametros.Add(new System.Data.SqlClient.SqlParameter("terminaEm", terminaEm));
            parametros.Add(new System.Data.SqlClient.SqlParameter("campoOrdenacao", campoOrdenacao));
            parametros.Add(new System.Data.SqlClient.SqlParameter("crescente", crescente));

            DataSet ds = base.Consultar("PesqPatient", parametros);
            List<DML.Patient> pat = Converter(ds);

            int iQtd = 0;

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                int.TryParse(ds.Tables[1].Rows[0][0].ToString(), out iQtd);

            qtd = iQtd;

            return cli;
        }
        internal void Alterar(DML.Patient patient)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Name", patient.Nome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("CPF", patient.Sobrenome));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Email", patient.Nacionalidade));
            parametros.Add(new System.Data.SqlClient.SqlParameter("Whatsapp", patient.CEP));

            base.Executar("AltPatient", parametros);
        }

        internal void Excluir(long Id)
        {
            List<System.Data.SqlClient.SqlParameter> parametros = new List<System.Data.SqlClient.SqlParameter>();

            parametros.Add(new System.Data.SqlClient.SqlParameter("Id", Id));

            base.Executar("DelPatient", parametros);
        }

        private List<DML.Patient> Converter(DataSet ds)
        {
            List<DML.Patient> lista = new List<DML.Patient>();
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DML.Patient pat = new DML.Patient();
                    pat.Id = row.Field<long>("Id");
                    pat.Name = row.Field<string>("Name");
                    pat.CPF = row.Field<string>("CPF");
                    pat.Email = row.Field<string>("Email");
                    pat.Whatsapp = row.Field<string>("Whatsapp");
                    lista.Add(pat);
                }
            }
            return lista;
        }
    }
}
