﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Syrus.Plugins.DFV2Client;
using Google.Cloud.Dialogflow.V2;

public class DF2ClientTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		DialogFlowV2Client client = GetComponent<DialogFlowV2Client>();

		client.ChatbotResponded += LogResponseText;
		client.DetectIntentError += LogError;

		Dictionary<string, string> parameters = new Dictionary<string, string>()
		{
			{ "name", "George" }
		};
		client.DetectIntentFromEvent("Welcome", parameters, "test");
    }

	private void LogResponseText(QueryResult result)
	{
		Debug.Log(name + " said: \"" + result.FulfillmentText + "\"");
	}

	private void LogError(long responseCode, string errorMessage)
	{
		Debug.LogError(string.Format("Error {0}: {1}", responseCode.ToString(), errorMessage));
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
