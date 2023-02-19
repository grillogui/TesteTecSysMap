using System.Text.Json.Serialization;

namespace TesteSysMap.src.utilidades
{
    /// <summary>
    /// <para>Resumo: Enum responsavel por definir Tipos de usuario do sistema</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary> 

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoUsuario
    {
        NORMAL,
        ADMINISTRADOR
    }
}
