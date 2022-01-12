﻿using System.Collections;
using UnityEngine;

namespace MecanimIKPlus
{
	
	public class IK_Foot_Linkage_CS : MonoBehaviour
	{

		public Transform bodyTarget;
		public Transform handTarget;
		public GameObject centerCamera;
		public float groundOffset = 0.1f;
		public float followSpeed = 2.5f;
		public float offsetX = 0.0f;
		public float offsetZ = -0.3f;
		public string inputName = "Grip L";

		Transform thisTransform;
		float initialDist;
		Vector3 targetPos;
		bool isWorking;
		float startDist;
		bool oncer = true;
		bool oncel = true;

		


		void Awake ()
		{
			thisTransform = transform;
			initialDist = Vector3.Distance (bodyTarget.position, thisTransform.position);
			targetPos = thisTransform.position;
		}

		void Update ()
		{
			Vector3 cameraPosition = centerCamera.transform.position;
			if (Input.GetAxis (inputName) > 0.0f) {
				if (isWorking == false) {
					isWorking = true;
					startDist = handTarget.position.y - thisTransform.position.y;
				}
				Move ();
			} else if (isWorking) {
				isWorking = false;
			}
			//bool oncer = true;
			//bool oncel = true;
			if(1.45 > cameraPosition.y)
			{
				double result = 1.45 - cameraPosition.y;
				double bairitu = result / 0.001;
				double fuehaba = bairitu * 0.0043;
				if(gameObject.name == "RightFootAnchor" && oncer == true)
				{
					targetPos.x += (float)fuehaba;
					Debug.Log("aaaaaaaaaa");
					oncer = false;
				}
				if(gameObject.name == "LeftFootAnchor" && oncel == true)
				{
					targetPos.x += -((float)fuehaba);
					Debug.Log("bbbbbbbbb");
					oncel = false;
				}
			}
			// Set position.
			thisTransform.position = Vector3.MoveTowards (thisTransform.position, targetPos, followSpeed * Time.deltaTime);
		}

		void Move ()
		{
			// Detect the ground.
			Ray ray = new Ray (handTarget.position, -Vector3.up);
			RaycastHit raycastHit;
			if (Physics.Raycast (ray, out raycastHit, 2.0f)) {
				targetPos = raycastHit.point + (Vector3.up * groundOffset);
			} else {
				targetPos.y = bodyTarget.position.y - initialDist;
			}
			// Set the target position.
			Vector3 footPos;
			Vector3 handPos = handTarget.position + (handTarget.right * offsetX) + (handTarget.forward * offsetZ);
			footPos.x = handPos.x;
			footPos.z = handPos.z;
			footPos.y = handTarget.position.y - startDist;
			if (footPos.y < targetPos.y) { // It should be under the ground.
				footPos.y = targetPos.y;
			}
			targetPos = footPos;
			// Set rotation.
			Vector3 footAngles = thisTransform.localEulerAngles;
			footAngles.y = handTarget.localEulerAngles.y;
			thisTransform.localEulerAngles = footAngles;
		}

	}

}
