using Soenneker.Telnyx.Messaging.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Telnyx.Messaging.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TelnyxMessagingUtilTests : HostedUnitTest
{
    private readonly ITelnyxMessagingUtil _util;

    public TelnyxMessagingUtilTests(Host host) : base(host)
    {
        _util = Resolve<ITelnyxMessagingUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
