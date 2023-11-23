import axios from 'axios'
const Api = axios.create({

    withCredentials: false,

    baseURL: "https://localhost:7126"

});

 

export default Api;