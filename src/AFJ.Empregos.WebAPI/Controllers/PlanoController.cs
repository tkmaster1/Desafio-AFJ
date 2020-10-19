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
    public class PlanoController : ApiController
    {
        #region Properties

        private readonly IPlanoAppService _planoAppService;

        #endregion

        #region Constructor

        public PlanoController(IPlanoAppService planoAppService)
        {
            _planoAppService = planoAppService;
        }

        #endregion

        #region Methods

        /// <summary>
        /// GET: Lista de todos os Planos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlanoViewModel> Get()
        {
            return _planoAppService.BuscarTodosAtivos();
        }

        /// <summary>
        /// GET: Busca por um Plano específico
        /// </summary>
        /// <param name="id">Identificador do Plano</param>
        /// <returns></returns>
        public PlanoViewModel Get(int id)
        {
            var plano = _planoAppService.ObterPorId(id);
            if (plano == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return plano;
        }

        /// <summary>
        /// POST: Inclui um Plano
        /// </summary>
        /// <param name="obj">Objeto com os dados do Plano à ser inserido</param>
        /// <returns></returns>
        public HttpResponseMessage Post(PlanoViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _planoAppService.Incluir(obj);

                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, obj);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = obj.PlanoId }));
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
        /// PUT: Altera um Plano
        /// </summary>
        /// <param name="id">Identificador do Plano</param>
        /// <param name="obj">Todos os outros dados deste Plano</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, PlanoViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != obj.PlanoId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                _planoAppService.Alterar(obj);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        ///  DELETE: Exclui um Plano
        /// </summary>
        /// <param name="id">Identificador do Plano</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            var plano = _planoAppService.ObterPorId(id);
            if (plano == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _planoAppService.Remover(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, plano);
        }

        [HttpGet]
        [Route("api/FiltrosEspecificos")]
        public IEnumerable<PlanoTelefoniaVOViewModel> FiltrosEspecificos(PlanoTelefoniaVOViewModel obj)
        {
            if (string.IsNullOrEmpty(obj.CodDDD))
            {
                var result = new List<PlanoTelefoniaVOViewModel>();
                var o = new PlanoTelefoniaVOViewModel { Mensagem = "Por favor, preencher os parâmetros." };

                result.Add(o);
                return result;
            }

            var ret = _planoAppService.FiltrosEspecificos(obj);

            return ret.Count > 0 ? ret : throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, "Nenhum registro encontrado."));
        }

        #endregion
    }
}