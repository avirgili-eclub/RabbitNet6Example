using Microsoft.AspNetCore.Http;
using RabbitMQ.Client;

namespace RabbitDemo.Common.Connections;

internal sealed class ChannelAccessor
{
    private static readonly ThreadLocal<ChannelHolder> Holder = new();

    public IModel? Channel
    {
        get => Holder.Value?.Context;
        set
        {
            var holder = Holder.Value;
            if (holder is not null)
            {
                holder.Context = null;
            }

            if (value is not null)
            {
                Holder.Value = new ChannelHolder { Context = value };
            }
        }
    }
    private class ChannelHolder
    {
        public IModel? Context;
    }
}