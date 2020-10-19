using AFJ.Empregos.Application.Interfaces;
using AFJ.Empregos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AFJ.Empregos.WebAPI.Controllers
{
    public class OperadoraController : ApiController
    {
        #region Properties

        private readonly IOperadoraAppService _operadoraAppService;

        #endregion

        #region Constructor

        public OperadoraController(IOperadoraAppService operadoraAppService)
        {
            _operadoraAppService = operadoraAppService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// GET: Lista de todos os Operadoras
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OperadoraViewModel> Get()
        {
            return _operadoraAppService.BuscarTodosAtivos();
        }

        /// <summary>
        /// GET: Busca por um Operadora específico
        /// </summary>
        /// <param name="id">Identificador do Operadora</param>
        /// <returns></returns>
        public OperadoraViewModel Get(int id)
        {
            var operadoraView = _operadoraAppService.ObterPorId(id);
            if (operadoraView == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return operadoraView;
        }

        /// <summary>
        /// POST: Inclui um Operadora
        /// </summary>
        /// <param name="obj">Objeto com os dados do Operadora à ser inserido</param>
        /// <returns></returns>
        public HttpResponseMessage Post(OperadoraViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _operadoraAppService.Incluir(obj);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, obj);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = obj.OperadoraId }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// PUT: Altera um Operadora
        /// </summary>
        /// <param name="id">Identificador do Operadora</param>
        /// <param name="obj">Todos os outros dados deste Operadora</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, OperadoraViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != obj.OperadoraId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _operadoraAppService.Alterar(obj);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        ///  DELETE: Exclui um Operadora
        /// </summary>
        /// <param name="id">Identificador do Operadora</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            var operadoraView = _operadoraAppService.ObterPorId(id);
            if (operadoraView == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _operadoraAppService.Remover(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, operadoraView);
        }

        #endregion
    }
}