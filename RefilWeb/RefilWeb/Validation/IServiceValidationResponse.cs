using System;
using System.Collections.Generic;

namespace RefilWeb.Validation
{
    public interface IServiceValidationResponse
    {
        IEnumerable<KeyValuePair<String, String>> GetErrors();
        bool IsValid { get; }
    }

    public interface IServiceValidationResponse<T>
    {
        T ServiceResultEntity { get; set; }
        IEnumerable<KeyValuePair<String, String>> GetErrors();
        bool IsValid { get; }
    }
}
