﻿using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;


[System.Serializable]
public class GamePlayer : ILocation
{
	//Assigned in order

	//0. Game init
	private int _clientId = -1;
	public int clientId {
		get {
			return _clientId;
		}
	}

	private int _locationId = -1;
	public int locationId { 
		get {
			return _locationId;
		}
	}

	private string _name;
	public string name { 
		get {
			return _name;
		}
	}

	//1. Deal cards
	public RealCard dealtCard;

	//2. Display prompts
	public int[] cohortLocations;
	public RealizedPrompt prompt;

	//3. Collect night actions - one selection per night action, in corresponding order
	public Selection nightLocationSelection;	

	//4. Manipulate cards
	private RealCard _currentCard;
	public RealCard currentCard { get {
			return _currentCard;
		}
		set {
			_currentCard = value;
		}
	}
	//public Mark currentMark;

	//5. Notify seers
	public List<Observation> observations;

	//6. Enable voting
	public int votedLocation;

	//7. Result
	public bool killed = false;
	public bool didWin;

	//	public Role originalRole;

	//	public Mark currentMark;
	//	public Artifact currentArtifact;

	public GamePlayer (GameMaster gameMaster, int clientId, string name)
	{
		this._clientId = clientId;
		this._name = name;

		this._locationId = gameMaster.RegisterLocation(this);
		this.observations = new List<Observation>();
	}

	public void ReceiveDealtCard(RealCard card) {
		this.dealtCard = card;
		this._currentCard = card;
	}
}
