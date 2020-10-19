using AFJ.Empregos.Application.Interfaces;
using AFJ.Empregos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AFJ.Empregos.WebAPI.Controllers
{
    public class DDDController : ApiController
    {
        #region Properties

        private readonly IDDDAppService _dddAppService;

        #endregion

        #region Constructor

        public DDDController(IDDDAppService dddAppService)
        {
            _dddAppService = dddAppService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// GET: Lista de todos os DDDs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DDDViewModel> Get()
        {
            return _dddAppService.BuscarTodosAtivos();
        }

        /// <summary>
        /// GET: Busca por um DDD específico
        /// </summary>
        /// <param name="id">Identificador do DDD</param>
        /// <returns></returns>
        public DDDViewModel Get(int id)
        {
            var dddView = _dddAppService.ObterPorId(id);
            if (dddView == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dddView;
        }

        /// <summary>
        /// POST: Inclui um DDD
        /// </summary>
        /// <param name="obj">Objeto com os dados do DDD à ser inserido</param>
        /// <returns></returns>
        public HttpResponseMessage Post(DDDViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dddAppService.Incluir(obj);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, obj);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = obj.DDDId }));
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
        /// PUT: Altera um DDD
        /// </summary>
        /// <param name="id">Identificador do DDD</param>
        /// <param name="obj">Todos os outros dados deste DDD</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, DDDViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != obj.DDDId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _dddAppService.Alterar(obj);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        ///  DELETE: Exclui um DDD
        /// </summary>
        /// <param name="id">Identificador do DDD</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            var dddView = _dddAppService.ObterPorId(id);
            if (dddView == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _dddAppService.Remover(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dddView);
        }

        #endregion
    }
}