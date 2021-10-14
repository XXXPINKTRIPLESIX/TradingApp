using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Response.Fiat
{
    public class FiatApiResponseDTO
    {
        public FiatResponseDTO SuccessResponse { get; set; }
        public FiatResponseErrorDto ErrorResponse { get; set; }
    }
}
