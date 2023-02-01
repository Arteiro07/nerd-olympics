import axios from 'axios'
import React from 'react'
import Player from './Player';

import { User } from '../types';

export default async function page() {

  const res = await axios.get(`https://dummyjson.com/users`);

  return (
    <>
      {res.data.users.map((User:User) => (
        <Player
          key={User.id}
          {...User}
        />
      ))}
    </>
  )
}
