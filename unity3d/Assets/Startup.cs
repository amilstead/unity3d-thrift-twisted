using UnityEngine;
using System.Collections;
using Services;
using Services.User;


public class Startup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        using (ThriftClient clientService = new ThriftClient("User.v1"))
        {
            User.Client client = (User.Client)clientService.GetClient();
            UserModel user = null;
            string username = "foo";
            string password = "bar";
            bool success = client.login(username, password);
            if (success)
            {
                Debug.Log("Login Success!");
            }
            else
            {
                Debug.Log("Login failed!");
                Debug.Log("Trying to create user");
                // try to create and login
                user = client.create(username, password);
                if (user.User_id != 0) {
                    Debug.Log("Created user!");
                    Debug.Log(user.ToString());
                    Debug.Log("Trying a login now.");
                    success = client.login(user.Username, user.Password);
                    if (success)
                    {
                        Debug.Log("Login succeeded!");
                    }
                    else
                    {
                        Debug.Log("login failed!");
                    }
                }
                else
                {
                    Debug.Log("User creation failed!");
                }                
            }

            user = client.get(username);
            if (user.User_id != 0)
            {
                Debug.Log("Got user from client:");
                Debug.Log(user.ToString());

                bool removed = client.remove(user.User_id);
                if (removed)
                {
                    Debug.Log("Successfully removed user with id: " + user.User_id);
                }
                else
                {
                    Debug.Log("Failed to remove user!");
                }
            }
            else
            {
                Debug.Log("Failed to get user with username: " + username);
            }

            
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
