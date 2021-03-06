/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Services.User
{
  public partial class User {
    public interface Iface : Services.SharedService.Iface {
      bool @remove(int user_id);
      #if SILVERLIGHT
      IAsyncResult Begin_remove(AsyncCallback callback, object state, int user_id);
      bool End_remove(IAsyncResult asyncResult);
      #endif
      UserModel create(string username, string password);
      #if SILVERLIGHT
      IAsyncResult Begin_create(AsyncCallback callback, object state, string username, string password);
      UserModel End_create(IAsyncResult asyncResult);
      #endif
      UserModel @get(string username);
      #if SILVERLIGHT
      IAsyncResult Begin_get(AsyncCallback callback, object state, string username);
      UserModel End_get(IAsyncResult asyncResult);
      #endif
      bool login(string username, string password);
      #if SILVERLIGHT
      IAsyncResult Begin_login(AsyncCallback callback, object state, string username, string password);
      bool End_login(IAsyncResult asyncResult);
      #endif
    }

    public class Client : Services.SharedService.Client, Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot) : base(iprot, oprot)
      {
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_remove(AsyncCallback callback, object state, int user_id)
      {
        return send_remove(callback, state, user_id);
      }

      public bool End_remove(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_remove();
      }

      #endif

      public bool @remove(int user_id)
      {
        #if !SILVERLIGHT
        send_remove(user_id);
        return recv_remove();

        #else
        var asyncResult = Begin_remove(null, null, user_id);
        return End_remove(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_remove(AsyncCallback callback, object state, int user_id)
      #else
      public void send_remove(int user_id)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("remove", TMessageType.Call, seqid_));
        remove_args args = new remove_args();
        args.User_id = user_id;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public bool recv_remove()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        remove_result result = new remove_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "remove failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_create(AsyncCallback callback, object state, string username, string password)
      {
        return send_create(callback, state, username, password);
      }

      public UserModel End_create(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_create();
      }

      #endif

      public UserModel create(string username, string password)
      {
        #if !SILVERLIGHT
        send_create(username, password);
        return recv_create();

        #else
        var asyncResult = Begin_create(null, null, username, password);
        return End_create(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_create(AsyncCallback callback, object state, string username, string password)
      #else
      public void send_create(string username, string password)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("create", TMessageType.Call, seqid_));
        create_args args = new create_args();
        args.Username = username;
        args.Password = password;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public UserModel recv_create()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        create_result result = new create_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "create failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_get(AsyncCallback callback, object state, string username)
      {
        return send_get(callback, state, username);
      }

      public UserModel End_get(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_get();
      }

      #endif

      public UserModel @get(string username)
      {
        #if !SILVERLIGHT
        send_get(username);
        return recv_get();

        #else
        var asyncResult = Begin_get(null, null, username);
        return End_get(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_get(AsyncCallback callback, object state, string username)
      #else
      public void send_get(string username)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("get", TMessageType.Call, seqid_));
        get_args args = new get_args();
        args.Username = username;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public UserModel recv_get()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        get_result result = new get_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "get failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_login(AsyncCallback callback, object state, string username, string password)
      {
        return send_login(callback, state, username, password);
      }

      public bool End_login(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_login();
      }

      #endif

      public bool login(string username, string password)
      {
        #if !SILVERLIGHT
        send_login(username, password);
        return recv_login();

        #else
        var asyncResult = Begin_login(null, null, username, password);
        return End_login(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_login(AsyncCallback callback, object state, string username, string password)
      #else
      public void send_login(string username, string password)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("login", TMessageType.Call, seqid_));
        login_args args = new login_args();
        args.Username = username;
        args.Password = password;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public bool recv_login()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        login_result result = new login_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "login failed: unknown result");
      }

    }
    public class Processor : Services.SharedService.Processor, TProcessor {
      public Processor(Iface iface) : base(iface)
      {
        iface_ = iface;
        processMap_["remove"] = remove_Process;
        processMap_["create"] = create_Process;
        processMap_["get"] = get_Process;
        processMap_["login"] = login_Process;
      }

      private Iface iface_;

      public new bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void remove_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        remove_args args = new remove_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        remove_result result = new remove_result();
        result.Success = iface_.@remove(args.User_id);
        oprot.WriteMessageBegin(new TMessage("remove", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void create_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        create_args args = new create_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        create_result result = new create_result();
        result.Success = iface_.create(args.Username, args.Password);
        oprot.WriteMessageBegin(new TMessage("create", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void get_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        get_args args = new get_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        get_result result = new get_result();
        result.Success = iface_.@get(args.Username);
        oprot.WriteMessageBegin(new TMessage("get", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void login_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        login_args args = new login_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        login_result result = new login_result();
        result.Success = iface_.login(args.Username, args.Password);
        oprot.WriteMessageBegin(new TMessage("login", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class remove_args : TBase
    {
      private int _user_id;

      public int User_id
      {
        get
        {
          return _user_id;
        }
        set
        {
          __isset.user_id = true;
          this._user_id = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool user_id;
      }

      public remove_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                User_id = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("remove_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.user_id) {
          field.Name = "user_id";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(User_id);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("remove_args(");
        bool __first = true;
        if (__isset.user_id) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("User_id: ");
          __sb.Append(User_id);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class remove_result : TBase
    {
      private bool _success;

      public bool Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public remove_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Bool) {
                Success = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("remove_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          field.Name = "Success";
          field.Type = TType.Bool;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Success);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("remove_result(");
        bool __first = true;
        if (__isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class create_args : TBase
    {
      private string _username;
      private string _password;

      public string Username
      {
        get
        {
          return _username;
        }
        set
        {
          __isset.username = true;
          this._username = value;
        }
      }

      public string Password
      {
        get
        {
          return _password;
        }
        set
        {
          __isset.password = true;
          this._password = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool username;
        public bool password;
      }

      public create_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Username = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Password = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("create_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Username != null && __isset.username) {
          field.Name = "username";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Username);
          oprot.WriteFieldEnd();
        }
        if (Password != null && __isset.password) {
          field.Name = "password";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Password);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("create_args(");
        bool __first = true;
        if (Username != null && __isset.username) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Username: ");
          __sb.Append(Username);
        }
        if (Password != null && __isset.password) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Password: ");
          __sb.Append(Password);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class create_result : TBase
    {
      private UserModel _success;

      public UserModel Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public create_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Struct) {
                Success = new UserModel();
                Success.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("create_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.Struct;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            Success.Write(oprot);
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("create_result(");
        bool __first = true;
        if (Success != null && __isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success== null ? "<null>" : Success.ToString());
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class get_args : TBase
    {
      private string _username;

      public string Username
      {
        get
        {
          return _username;
        }
        set
        {
          __isset.username = true;
          this._username = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool username;
      }

      public get_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Username = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("get_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Username != null && __isset.username) {
          field.Name = "username";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Username);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("get_args(");
        bool __first = true;
        if (Username != null && __isset.username) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Username: ");
          __sb.Append(Username);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class get_result : TBase
    {
      private UserModel _success;

      public UserModel Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public get_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Struct) {
                Success = new UserModel();
                Success.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("get_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.Struct;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            Success.Write(oprot);
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("get_result(");
        bool __first = true;
        if (Success != null && __isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success== null ? "<null>" : Success.ToString());
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class login_args : TBase
    {
      private string _username;
      private string _password;

      public string Username
      {
        get
        {
          return _username;
        }
        set
        {
          __isset.username = true;
          this._username = value;
        }
      }

      public string Password
      {
        get
        {
          return _password;
        }
        set
        {
          __isset.password = true;
          this._password = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool username;
        public bool password;
      }

      public login_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                Username = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Password = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("login_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Username != null && __isset.username) {
          field.Name = "username";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Username);
          oprot.WriteFieldEnd();
        }
        if (Password != null && __isset.password) {
          field.Name = "password";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Password);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("login_args(");
        bool __first = true;
        if (Username != null && __isset.username) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Username: ");
          __sb.Append(Username);
        }
        if (Password != null && __isset.password) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Password: ");
          __sb.Append(Password);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class login_result : TBase
    {
      private bool _success;

      public bool Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public login_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.Bool) {
                Success = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("login_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          field.Name = "Success";
          field.Type = TType.Bool;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Success);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("login_result(");
        bool __first = true;
        if (__isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }

  }
}
