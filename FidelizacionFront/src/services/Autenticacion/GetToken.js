import configData from '../../config.json'

const GetToken = async (username, password) => {
  try {
    const response = await fetch(
      configData.SERVER_URL + '/api/Usuarios/' + username + '/' + password,
      {
        method: 'GET',
        mode: 'cors',
        headers: {
          'Access-Control-Allow-Origin': '*',
          accept: 'text/plain',
          'sec-fetch-mode': 'cors',
          'Access-Control-Allow-Headers': 'Content-Type',
          'Access-Control-Allow-Methods': 'OPTIONS,POST,GET',
        },
      },
    )
    if (response.status == 200) {
      let json = await response.json()
      return json
    }
    return null
    // eslint-disable-next-line prettier/prettier
  } catch (error) { }
}

export default GetToken
