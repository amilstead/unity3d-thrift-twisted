using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;
using Services;


public class ThriftClient : IDisposable
{
    private string serviceName;
    private string serviceHost;
    private int servicePort;
    private TTransport transport;
    private TProtocol baseProtocol;
    private TMultiplexedProtocol protocol;

    private Dictionary<string, string> serviceMap = new Dictionary<string, string>() {
        {"User.v1", "Services.User.User+Client"}
    };

    public ThriftClient(string serviceName, string serviceHost = "127.0.0.1", int servicePort = 8001)
    {
        this.serviceName = serviceName;
        this.serviceHost = serviceHost;
        this.servicePort = servicePort;
        this.InitProtocol();
    }

    private void InitProtocol()
    {
        this.transport = new TFramedTransport(new TSocket(this.serviceHost, this.servicePort));
        this.baseProtocol = new TBinaryProtocol(this.transport);
        this.protocol = new TMultiplexedProtocol(this.baseProtocol, this.ServiceName);
    }

    public SharedService.Iface GetClient()
    {
        string className = this.serviceMap[this.serviceName];
        Type objectType = Type.GetType(className);
        SharedService.Iface client = (SharedService.Iface)Activator.CreateInstance(objectType, this.protocol);
        this.transport.Open();
        return client;
    }

    public string ServiceName
    {
        get
        {
            return this.serviceName;
        }
    }

    public void Dispose()
    {
        this.transport.Close();
    }
}
