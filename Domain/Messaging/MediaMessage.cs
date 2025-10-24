using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messaging
{
    // Shared between API and Worker
    public record MediaMessage(
        string TempPath,
        string ObjectName,
        string ContentType,
        long Size
    );

}
