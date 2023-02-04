import axios from 'axios'
import Player from './Player';
import style  from "./players.module.scss";
import { User } from '../types';

export default async function page() {

    const res = await axios.get(`https://dummyjson.com/users`);
    
      return (
        <div className={style.container}>
          {res.data.users.map((user:User) => (
            <Player
              key={user.id}
              {...user}
            />
          ))}
        </div>
      )
}
