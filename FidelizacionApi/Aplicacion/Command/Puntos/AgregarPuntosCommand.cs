﻿using MediatR;

namespace Aplicacion.Command.Puntos
{
    public class AgregarPuntosCommand : IRequest<bool>
    {
        public AgregarPuntosCommand(float valorVenta, string factura, string documentoFidelizado, string nitCentroVenta)
        {
            ValorVenta = valorVenta;
            Factura = factura;
            DocumentoFidelizado = documentoFidelizado;
            NitCentroVenta = nitCentroVenta;
        }
        public float ValorVenta { get; set; }
        public string Factura { get; set; }
        public string DocumentoFidelizado { get; set; }
        public string NitCentroVenta { get; set; }

    }
}
