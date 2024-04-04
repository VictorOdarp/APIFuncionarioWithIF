using System.Text.Json.Serialization;

namespace APIFuncionariosIF.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentEnum
    {
        RH,
        Financeiro,
        Compras,
        Atendimento,
        Zeladoria
    }
}
