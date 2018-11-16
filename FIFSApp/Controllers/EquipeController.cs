using FIFSApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIFSApp.Controllers
{
    public class EquipeController : Controller
    {
        // GET: Equipe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllEquipe());
        }

        IEnumerable<Equipe> GetAllEquipe()
        {
            using (DBModel db = new DBModel())
            {
                return db.Equipe.ToList<Equipe>();
            }
        }

        public ActionResult AddOrEdit(int id=0)
        {
            Equipe equipe = new Equipe();            

            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    equipe = db.Equipe.Where(x => x.Id == id).FirstOrDefault<Equipe>();
                }
            }
            return View(equipe);
        }

        [HttpPost]
        public ActionResult AddOrEdit (Equipe equipe)
        {
            try
            {
                //se tiver alguma imagem para upload será salva na pasta indicada
                if (equipe.UploadImagem != null)
                {
                    string nomeArquivo = Path.GetFileNameWithoutExtension(equipe.UploadImagem.FileName);
                    string extensao = Path.GetExtension(equipe.UploadImagem.FileName);
                    nomeArquivo = nomeArquivo + DateTime.Now.ToString("yymmssfff") + extensao;
                    equipe.Imagem = "~/Arquivos/Imagens/" + nomeArquivo;
                    equipe.UploadImagem.SaveAs(Path.Combine(Server.MapPath("~/Arquivos/Imagens/"), nomeArquivo));
                }

                using (DBModel db = new DBModel())
                {
                    if (equipe.Id == 0)
                    {
                        db.Equipe.Add(equipe);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(equipe).State = EntityState.Modified;
                        db.SaveChanges();
                    }                    
                }
                //return RedirectToAction("Index");
                return Json(new { success = true, html = ClasseGlobal.RenderRazorViewToString(this, "ViewAll", GetAllEquipe()), message = "Cadastrado com Sucesso!" }, JsonRequestBehavior.AllowGet);
                //return Json(new { success = true, html = ClasseGlobal.RenderRazorViewToString(this, "ViewAll", GetAllEquipe()), message = "Submited Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false,  message = ex.Message}, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id) {
            try
            {
                using (DBModel db = new DBModel())
                {
                    Equipe equipe = db.Equipe.Where(x => x.Id == id).FirstOrDefault<Equipe>();
                    db.Equipe.Remove(equipe);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = ClasseGlobal.RenderRazorViewToString(this, "ViewAll", GetAllEquipe()), message = "Apagado com Sucesso!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}