> NOTE: Thrift [dropped support for C#](https://github.com/apache/thrift/blob/master/CHANGES.md#0140) in `0.14.0`. In theory, this code should work for versions `0.13.0` and earlier.

# unity3d-thrift-twisted

This is a demo codebase for linking up a [Unity3D](http://unity3d.com/) client with a [python twisted](https://twistedmatrix.com/trac/) server using the [Apache Thrift](https://thrift.apache.org/) RPC toolset.

The main reason this was created was due to lack of examples and/or information on how to get these two systems to communicate using Thrift.

The project was tested using a Windows client and a Ubuntu 14.04 server.

The project is split into three parts:
## C#/Unity3D ##

The [unity3d folder](unity3d) contains a Visual Studio project, generated C# Thrift source files, a collection of Unity3D assets, and a Unity3D Scene with a Startup script attached.

The Startup script uses a small [context-managed](https://msdn.microsoft.com/en-us/library/yh598w02.aspx) wrapper object that simply sets up a mapping between generated sources to provide an easy client connection API.


## python/twisted ##
The [python folder](python) contains a python-twisted application, generated python-twisted source files, and a requirements file (for easy pip-based installation) to demonstrate a twisted server using generated Thrift RPC code.

The python application also employs the use of [SQLAlchemy](http://www.sqlalchemy.org/) for simple data access and a [small helper class](python/app/services/core.py) for mapping services into a multi-service server.

**NOTE**: While the demo app uses the SQLAlchemy ORM, it is primarily for **demonstration purposes only**. There have been a number of discussions (see [here](http://stackoverflow.com/questions/21076105/is-this-an-acceptable-way-to-make-threaded-sqlalchemy-queries-from-twisted) and [here](http://stackoverflow.com/questions/3017101/twisted-sqlalchemy-and-the-best-way-to-do-it)) on the considerations one needs to take when using SQLAlchemy's ORM with the Twisted framework, as well as a [library](http://blog.atleastfornow.net/2013/alchimia/) which supports non-blocking DB calls. In all likelihood, using the SQLAlchemy ORM out of the box with Twisted is probably a bad idea. It was just the easiest thing to get up and running for a tutorial on Thrift integration.

## Thrift ##
The [thrift folder](thrift) contains two `.thrift` files used by the thrift binary to generate both twisted specific python and C# sources for the project.

The files are fairly simple. 

`core.thrift`:

Contains a shared service object which the `user` service inherits from.

`user.thrift`:

Contains a user service and a struct definition for sending users back and forth from server to client.

There is extensive documentation on the thrift protocol all across the interwebs and a wonderful [example file](https://git-wip-us.apache.org/repos/asf?p=thrift.git;a=blob_plain;f=tutorial/tutorial.thrift) in the source code.

See [here](https://thrift.apache.org/tutorial/csharp.html) for an example of how to compile Thrift definitions for C#.

# Installation #
Now onto setting up the projects!
## Python ###
My personal preference for python development is the [PyCharm IDE](https://www.jetbrains.com/pycharm/) but whatever your preference -- all you really need is the ability to install the package dependencies and to run the `main.py` file.

### Virtualenv ###
To get your environment setup, I'd suggest using a [virtual environment](https://virtualenv.pypa.io/en/latest/) (in addition -- I find [virtualenvwrapper](https://virtualenvwrapper.readthedocs.org/en/latest/) to be quite handy).

Create the virtual environment and install the requirements:


	virtualenv <my/virtualenv/directory>/unity3d-thrift-twisted
	source <my/virtualenv/directory>/unity3d-thrift-twisted/bin/activate
	pip install -r python/requirements.txt

That's it! Now you're ready to run the server and start listening for thrift connections.

The start the server, just run the commands:

	cd python/app
	python main.py

You can specify an optional `--port` argument if you'd like it to listen on something other than `8001`.

## C#/Unity3D ##

Make sure you have Unity3D downloaded and installed.

I used the Unity3D free edition (which means desktop project builds **only**) and I have not attempted to deploy it to any other platforms. I'd wager there might be complications in the event that I did.

Open Unity3D, then go to `File > Open Project > Open Other...`

Browse to the `unity3d` folder and click `Select Folder`.

Once the project is loaded, simply press the play button at the top of the editor and view console output to verify the client and server are interacting properly.


## FAQs ##

*"I keep getting `SocketException: No connection could be made because the target machine actively refused it.` when I press the play button. pls halp to shot web?"*


That means:

1. The client is not pointing to the right IP address/Port
2. The server isn't running
3. You have some local firewall blocking connections from client to server.

By default, the server listens on all interfaces (`0.0.0.0`). To see what your server's IP address is, just run the command (assuming a linux machine): `ifconfig`

----------

*"How do I change the IP/Port that my server is trying to connect to?"*

To change the IP reference for the server, go to [the Startup script](unity3d/Assets/Startup.cs) and change the following lines to reference your server's IPv4 address and/or port:

	using (ThriftClient clientService = new ThriftClient("User.v1"))
to:

	using (ThriftClient clientService = new ThriftClient(
		"User.v1", 
		serviceHost: "<your server IP>", 
		servicePort: <some integer port>)
	)



----------
*"Unity keeps complainig about unliked libraries/Thrift won't compile with the Unity project. What gives?"*

You may need to compile it yourself or find some way of acquiring the linked library (I'd suggest downloading and compiling the source, as a Visual Studio solution for doing so is included in the Thrift source code). If this happens, after you've acquired a good version of the DLL, simply open the Unity project then drag the DLL file into the unity editor and drop it onto the `Assets` folder.

----------

