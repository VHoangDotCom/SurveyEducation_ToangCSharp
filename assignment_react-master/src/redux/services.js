import axios from "axios"; //package gui 1 request len server


const postServey = (data) => {
  return axios.post(`http://localhost:3000/survey`,{
    method: 'POST',
    body: JSON.stringify(data),
    headers: { 'Content-Type': 'application/json' }}, data);
};
export {
    postServey
};
