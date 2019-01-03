using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DR.Condominus.Application.Interfaces;
using DR.Condominus.Application.Services;
using DR.Condominus.Application.ViewModels;
using DR.Condominus.UI.Site.Models;

namespace DR.Condominus.UI.Site.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        public ActionResult Details(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return View(clienteEndereco);

            _clienteAppService.Adicionar(clienteEndereco);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            ClienteViewModel clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            _clienteAppService.Atualizar(clienteViewModel);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _clienteAppService.Dispose();
        }
    }
}
