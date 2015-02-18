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
            UserModel newUser = client.create("foo", "bar");
            string response = "Creation failed!";
            if (newUser.User_id != 0)
            {
                response = "Successfully created user!";
            }
            Debug.Log(response);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
