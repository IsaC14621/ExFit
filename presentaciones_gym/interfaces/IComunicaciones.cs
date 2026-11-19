using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_gym.interfaces
{
    public interface IComunicaciones
    {
        Task<T> Ejecutar<T>(string url, object entidad);
    }
}
