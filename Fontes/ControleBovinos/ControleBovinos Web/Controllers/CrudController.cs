using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.bos;
using com.rerum.app;
using com.rerum.sys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ControleBovinos_Web.Models;
using com.rerum.rpo;

namespace ControleBovinos_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {

        protected RPOApplication RpoApp { get; set; }
        public void InitRpoApplication()
        {
            RpoApp = new RPOApplication("Application");
            if (RpoApp.init() != RStatus.OK)
            {
                throw new TypeInitializationException(typeof(RPOApplication).FullName, null);
            }
        }
        public void TerminateRpoApplication()
        {
            if (RpoApp != null)
            {
                RpoApp.terminate();
            }
        }

        // GET: api/Crud
        [HttpGet]
        public List<BovinoModel> Get()
        {
            InitRpoApplication();
            var trn = new application.trn.TRNBovino();
            trn.ExecConsultarBovinos();
            if (trn.hasError() || trn == null)
            {
                Console.WriteLine("Erro");
            }
            List<BovinoModel> list = new List<BovinoModel>();
            foreach (Bovino p in trn.RetornoConsulta)
            {
                BovinoModel bovino = new BovinoModel();
                bovino.cod_objeto = p.getObjectIdStr();
                bovino.nome = p.getNome();
                bovino.brinco = p.getBrinco();
                bovino.brincoPai = p.getBrincoPai();
                bovino.brincoMae = p.getBrincoMae();
                bovino.sexo = p.getSexo();
                bovino.situacao = p.getSituacao();
                bovino.raca = p.getRaca();
                bovino.dataNascimento = p.getDataNascimento();
                bovino.dataPrenches = p.getDataPrenches();
                bovino.dataUltimoParto = p.getDataUltimoParto();

                list.Add(bovino);
            }
            TerminateRpoApplication();
            return list;
        }


        // GET: api/Crud/5
        [HttpGet("{tipo}/{valor}")]
        public List<BovinoModel> GetByNameOrBrinco(string tipo, string valor)
        {
            InitRpoApplication();
            var trn = new application.trn.TRNBovino();
            //throw new Exception("tipo: "+tipo+" valor: "+valor);
            if(tipo=="brinco")
                trn.Brinco = valor;
            else
                trn.Nome = valor;
            trn.ExecConsultarBovinos();
            if (trn.hasError() || trn == null)
            {
                Console.WriteLine("Erro");
            }

            List<BovinoModel> list = new List<BovinoModel>();
            foreach (Bovino p in trn.RetornoConsulta)
            {
            
                BovinoModel bovino = new BovinoModel();
                bovino.cod_objeto = p.getObjectIdStr();
                bovino.nome = p.getNome();
                bovino.brinco = p.getBrinco();
                bovino.brincoPai = p.getBrincoPai();
                bovino.brincoMae = p.getBrincoMae();
                bovino.sexo = p.getSexo();
                bovino.situacao = p.getSituacao();
                bovino.raca = p.getRaca();
                bovino.dataNascimento = p.getDataNascimento();
                bovino.dataPrenches = p.getDataPrenches();
                bovino.dataUltimoParto = p.getDataUltimoParto();


                list.Add(bovino);
            
            }
            TerminateRpoApplication();
            return list;
        }


        // GET: api/Crud/5
        [HttpGet("{id}")]
        public BovinoModel GetById(string id)
        {
            InitRpoApplication();
            var trn = new application.trn.TRNBovino();
            trn.ExecConsultarBovinos();
            if (trn.hasError() || trn == null)
            {
                Console.WriteLine("Erro");
            }
            BovinoModel bovino = new BovinoModel();
            foreach (Bovino p in trn.RetornoConsulta)
            {
                if (p.getObjectIdStr() == id)
                {
                    bovino.cod_objeto = p.getObjectIdStr();
                    bovino.nome = p.getNome();
                    bovino.brinco = p.getBrinco();
                    bovino.brincoPai = p.getBrincoPai();
                    bovino.brincoMae = p.getBrincoMae();
                    bovino.sexo = p.getSexo();
                    bovino.situacao = p.getSituacao();
                    bovino.raca = p.getRaca();
                    bovino.dataNascimento = p.getDataNascimento();
                    bovino.dataPrenches = p.getDataPrenches();
                    bovino.dataUltimoParto = p.getDataUltimoParto();

                    if (trn.hasError())
                    {
                        Console.WriteLine("Erro");
                        break;
                    }
                    break;
                }
            }
            TerminateRpoApplication();
            return bovino;
        }





        [HttpPost]
        public BovinoModel Post([FromBody] BovinoModel bovino)
        {
            InitRpoApplication();
            // Se o corpo (Body) estiver vazio, há um erro
            if (bovino == null)
            {
                throw new Exception("O corpo não pode estar vazio.");
            }
            var trn = new application.trn.TRNBovino();
            if (trn.hasError())
            {
                Console.WriteLine("Erro");
            }
            Bovino newBovino = new application.bos.Bovino();
            newBovino.setNome(bovino.nome);
            newBovino.setBrinco(bovino.brinco);
            newBovino.setBrincoPai(bovino.brincoPai);
            newBovino.setBrincoMae(bovino.brincoMae);

            newBovino.setSexo(bovino.sexo);
            newBovino.setSituacao(bovino.situacao);
            newBovino.setRaca(bovino.raca);
            newBovino.setDataNascimento(bovino.dataNascimento);
            newBovino.setDataPrenches(bovino.dataPrenches);
            newBovino.setDataUltimoParto(bovino.dataUltimoParto);

            validacaoBovino(newBovino);

            trn.Bovino = newBovino;
            trn.ExecManterBovino();
            TerminateRpoApplication();
            return bovino;
        }

        private void validacaoBovino(Bovino bovino)
        {
            var trn = new application.trn.TRNBovino();


            if (bovino.getNome().isNullOrEmpty() || bovino.getBrinco().isNullOrEmpty())
            {
                throw new Exception("Bovino vazio.");


            }
            else
            {

                pesquisaBovino(bovino.getBrinco(), ref trn);
                if (trn.RetornoConsulta.Count>0 && !trn.RetornoConsulta.isNullOrEmpty())
                {
                    throw new Exception("Bovino Existente.");

                }
            }



            if (!parenteValido(bovino.getBrincoPai(),ref trn,"macho"))
                throw new Exception("Pai Inválido.");

          
            if (!parenteValido(bovino.getBrincoMae(),ref trn,"femea"))
                throw new Exception("Mãe Inválida.");


        }

        private bool parenteValido(string brinco, ref application.trn.TRNBovino trn, string sexo)
        {

            if (!string.IsNullOrEmpty(brinco))
            {

                pesquisaBovino(brinco, ref trn);
                if (trn.RetornoConsulta.Count > 0 && !trn.RetornoConsulta.isNullOrEmpty())
                {
                    foreach (Bovino b in trn.RetornoConsulta)
                    {
                        if (b.getSexo() != sexo)
                            return false;

                    }
                }
                else
                {
                    return false;

                }


            }

            return true;

        }

        private void pesquisaBovino(string brinco, ref application.trn.TRNBovino trn)
        {
            trn = new application.trn.TRNBovino();
            trn.Brinco = brinco;
            trn.ExecConsultarBovinos();
        }


        // PUT: api/Crud/5
        [HttpPut("{id}")]
        public BovinoModel Put(string id, [FromBody] BovinoModel bovino)
        {
            InitRpoApplication();
            var trn = new application.trn.TRNBovino();
            trn.ExecConsultarBovinos();
            //throw new Exception("numero: " + trn.RetornoConsulta.Count);
            if (id == null)
            {
                throw new Exception("O id não foi fornecido.");
            }
            // Se o corpo (Body) estiver vazio, há um erro
            if (bovino == null)
            {
                throw new Exception("O corpo não pode estar vazio.");
            }
            if (trn.hasError() || trn == null)
            {
                Console.WriteLine("Erro");
            }
            foreach (Bovino b in trn.RetornoConsulta)
            {
                Console.WriteLine(b.getObjectIdStr());
                if (b.getObjectIdStr() == id)
                {
                    if (!parenteValido(bovino.brincoPai, ref trn, "macho"))
                        throw new Exception("Pai Inválido.");


                    if (!parenteValido(bovino.brincoMae, ref trn, "femea"))
                        throw new Exception("Mãe Inválida.");

                    trn = new application.trn.TRNBovino();
                    trn.Bovino = b;
                    trn.Bovino.setNome(bovino.nome);
                    trn.Bovino.setBrinco(bovino.brinco);
                    trn.Bovino.setBrincoPai(bovino.brincoPai);
                    trn.Bovino.setBrincoMae(bovino.brincoMae);
                    trn.Bovino.setSexo(bovino.sexo);
                    trn.Bovino.setSituacao(bovino.situacao);
                    trn.Bovino.setRaca(bovino.raca);
                    trn.Bovino.setDataNascimento(bovino.dataNascimento);
                    trn.Bovino.setDataPrenches(bovino.dataPrenches);
                    trn.Bovino.setDataUltimoParto(bovino.dataUltimoParto);

                    bovino.cod_objeto = b.getObjectIdStr();


                    trn.ExecManterBovino();
                    if (trn.hasError())
                    {
                        Console.WriteLine("Erro");
                        break;
                    }
                    break;
                }
            }
            TerminateRpoApplication();
            return bovino;
        }


       [HttpDelete("{id}")]
        public void Delete(string id)
        {
            InitRpoApplication();
            var trn = new application.trn.TRNBovino();
            if (id == null)
            {
                throw new Exception("O id não foi fornecido.");
            }
            trn.ExecConsultarBovinos();
            if (trn.hasError() || trn == null)
            {
                Console.WriteLine("Erro");
            }
            foreach (Bovino p in trn.RetornoConsulta)
            {
                Console.WriteLine(p.getObjectIdStr());
                if (p.getObjectIdStr() == id)
                {
                    trn = new application.trn.TRNBovino();
                    trn.Bovino = p;
                    trn.Bovino.delete();
                    break;
                }
            }
            TerminateRpoApplication();
        }





    }
}
