using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;

namespace WpfApplication1.DAL
{
    class RegistroDAO
    {
        private static Context ctx = Singleton.Instance.Context;
        private static List<Registro> registros = new List<Registro>();

        public bool tem = false;
        public string mensagem = ""; //tudo ok
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;

        public bool SalvarCaixa(Registro caixa)
        {
            tem = false;
            // comandos para inserir 
            cmd.CommandText = @"insert into registros values ('"+ caixa.TipoDeServico + "'," + caixa.ValorServico + "," + caixa.Cliente.ClienteId + ", '" + caixa.DataServico.ToString() + "')";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Salvo com Sucesso!!!";
                tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return tem;
        }

        public Decimal SelectSaldo()
        {
            Decimal saldoPet = 0;
            // comando para mostrar os dados da tabela 
            cmd.CommandText = @"Select ISNULL(SUM(ValorServico),0) as saldo From registros";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { // pega todos os item da tabela
                    saldoPet += Convert.ToDecimal(reader["saldo"]);  
                }
                con.Desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }
            return saldoPet;
        }

        public List<Registro> SelectAll()
        {
            List<Registro> lstRegistro = new List<Registro>();
            tem = false;
            // comando para mostrar os dados da tabela 
            cmd.CommandText = @"Select  * From Registros";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con.conectar();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                { // pega todos os item da tabela
                    var registro = new Registro();
                    registro.RegistroId = Convert.ToInt32(reader["RegistrosId"]);
                    registro.TipoDeServico = reader["TipoDeServico"].ToString();
                    registro.ValorServico = Convert.ToDecimal(reader["ValorServico"]);
                    registro.Cliente = new Cliente() { ClienteId = Convert.ToInt32(reader["Cliente"]) };
                    registro.DataServico = reader["DataServico"].ToString();

                    lstRegistro.Add(registro);
                }
                con.Desconectar();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com Banco de Dados";
            }

            return lstRegistro;
        }
    }
}







        
