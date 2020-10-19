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
    public class TipoPlanoController : ApiController
    {
        #region Properties

        private readonly ITipoPlanoAppService _tipoPlanoAppService;

        #endregion

        #region Constructor

        public TipoPlanoController(ITipoPlanoAppService tipoPlanoAppService)
        {
            _tipoPlanoAppService = tipoPlanoAppService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// GET: Lista de todos os TipoPlanos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipoPlanoViewModel> Get()
        {
            return _tipoPlanoAppService.BuscarTodosAtivos();
        }

        /// <summary>
        /// GET: Busca por um TipoPlano específico
        /// </summary>
        /// <param name="id">Identificador do TipoPlano</param>
        /// <returns></returns>
        public TipoPlanoViewModel Get(int id)
        {
            var tipoPlanoView = _tipoPlanoAppService.ObterPorId(id);
            if (tipoPlanoView == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return tipoPlanoView;
        }

        /// <summary>
        /// POST: Inclui um TipoPlano
        /// </summary>
        /// <param name="obj">Objeto com os dados do TipoPlano à ser inserido</param>
        /// <returns></returns>
        public HttpResponseMessage Post(TipoPlanoViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tipoPlanoAppService.Incluir(obj);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, obj);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = obj.TipoPlanoId }));
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
        /// PUT: Altera um TipoPlano
        /// </summary>
        /// <param name="id">Identificador do TipoPlano</param>
        /// <param name="obj">Todos os outros dados deste TipoPlano</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, TipoPlanoViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != obj.TipoPlanoId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _tipoPlanoAppService.Alterar(obj);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        ///  DELETE: Exclui um TipoPlano
        /// </summary>
        /// <param name="id">Identificador do TipoPlano</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            var tipoPlanoView = _tipoPlanoAppService.ObterPorId(id);
            if (tipoPlanoView == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _tipoPlanoAppService.Remover(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tipoPlanoView);
        }

        #endregion
    }
}
