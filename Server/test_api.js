const axios = require('axios');

async function test() {
  try {
    const loginRes = await axios.post('http://localhost:5254/api/auth/login', {
      username: 'admin',
      password: 'Admin@123!'
    });
    const token = loginRes.data.token;
    
    console.log("Got token. Calling create group...");

    const res = await axios.post('http://localhost:5254/api/schema/groups', {
      name: 'testnode',
      sqlTableName: 'btn1_testnode',
      cardinality: '1:1',
      description: 'test node',
      tierId: 1
    }, {
      headers: { Authorization: `Bearer ${token}` }
    });

    console.log("Success:", res.data);
  } catch (err) {
    if (err.response) {
      console.log("Error Response Status:", err.response.status);
      console.log("Error Response Headers:", err.response.headers);
      console.log("Error Response Data:", JSON.stringify(err.response.data, null, 2));
    } else {
      console.log("Error:", err.message);
    }
  }
}

test();
