using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Response;

namespace API.UneCont.Response;
public record DocumentoConsultaResponse(long UltimoEventoUsuarioId, long MaximoEventoUsuarioId, ICollection<DocumentoResponse> ListaEventosDocumentos);
