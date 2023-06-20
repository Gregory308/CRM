import axios from "axios";

export const BASE_URL = "https://localhost:7002/";

export const CreateApiEndpoint = endpoint => {
    let url = BASE_URL + 'api/' + endpoint + '/'
}

