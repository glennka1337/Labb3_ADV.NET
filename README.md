1. [
  {
    "id": 1,
    "name": "Alice",
    "phoneNumber": "123456",
    "interests": [
      {
        "id": 1,
        "title": "Fotboll",
        "description": "Lagsport med boll"
      },
      {
        "id": 2,
        "title": "Gitarr",
        "description": "Stränginstrument"
      }
    ]
  },
  {
    "id": 2,
    "name": "Bob",
    "phoneNumber": "654321",
    "interests": [
      {
        "id": 1,
        "title": "Fotboll",
        "description": "Lagsport med boll"
      },
      {
        "id": 2,
        "title": "Gitarr",
        "description": "Stränginstrument"
      }
    ]
  }
]

2. [
  {
    "id": 1,
    "title": "Fotboll",
    "description": "Lagsport med boll",
    "personInterests": []
  },
  {
    "id": 2,
    "title": "Gitarr",
    "description": "Stränginstrument",
    "personInterests": []
  }
]

3. [
  {
    "id": 1,
    "url": "https://fotboll.se",
    "personId": 1,
    "interestId": 1,
    "personInterest": null
  },
  {
    "id": 2,
    "url": "https://gitarrlektioner.com",
    "personId": 1,
    "interestId": 2,
    "personInterest": null
  },
  {
    "id": 4,
    "url": "www.youtube.com",
    "personId": 1,
    "interestId": 2,
    "personInterest": null
  }
]

4. curl -X 'POST' \
  'https://localhost:7095/api/Persons/1/interests' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '2'

5. curl -X 'POST' \
  'https://localhost:7095/api/Persons/1/interests/1/links' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '"www.google.com"'
