using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pessoa.Api.Models.DTO.EnderecoDTO;
using Pessoa.Api.Models.DTO.PessoalDTO;
using Pessoa.Entity.Endereco;
using Pessoa.Entity.Pessoal;
using Pessoa.Infra;

namespace Pessoa.Api.Controllers
{
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        private readonly PeopleContext _context;
        private readonly IMapper _map;
        public PeopleController(PeopleContext context, IMapper map)
        {
            _map = map;
            _context = context;
        }

        [HttpGet]// GET: PeopleController
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet("getall/")]// GET: PeopleController
        public JsonResult GetAll()
        {
            var pessoas = _context.Pessoas.Include(x => x.Endereco).ToList();
            return Json(_map.Map<List<ReadPessoalDTO>>(pessoas));
        }

        // GET: PeopleController/Details/5
        [HttpGet("{id}")]
        public JsonResult Details(int id)
        {
            var pessoa = _context.Pessoas.Where(p => p.PessoaId == id).Include(p => p.Endereco).FirstOrDefault();

            var mapped = _map.Map<ReadPessoalDTO>(pessoa);


            return Json(mapped);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreatePessoalDTO pessoalDTO)
        {
            var pessoa = _map.Map<CreatePessoalDTO, People>(pessoalDTO);
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            
            return Ok(pessoa);

        }

        // POST: PeopleController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: PeopleController/Edit/5
        [HttpPut("{id}")]
        public JsonResult EditPessoa(int id, [FromBody] UpdatePessoalDTO upPessoal)
        {
            var pessoal = _context.Pessoas.Find(id);

            if (pessoal == null) return Json("'message':'bad'");
            _map.Map(upPessoal, pessoal);
            _context.SaveChanges();

            return Json(pessoal);
        }


        // GET: PeopleController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pessoal = _context.Pessoas.Find(id);
            if (pessoal == null) return BadRequest();
            _context.Pessoas.Remove(pessoal);
            _context.SaveChanges();
            return Ok("Deleted");
        }

        //// POST: PeopleController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
