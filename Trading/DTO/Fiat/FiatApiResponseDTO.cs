using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Fiat
{
    public class FiatApiResponseDTO
    {
        public FiatResponseDTO SuccessResponse { get; set; }
        public FiatResponseErrorDto ErrorResponse { get; set; }
    }
}
