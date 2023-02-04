import React from 'react'
import Image from 'next/image'
import Link from 'next/link'
import { User } from '../types';
import style from "./player.module.scss";

export default function Player(user : User ) {
  return (
    
    <>  
      <div className={style.card}>
        <Link href= {`/players/${user.id}`} >
          <Image 
              src={user.image}
              alt={"icon"}
              width={30}
              height={30}
          />
          {user.id}, {user.firstName} {user.lastName}, {user.age}, {user.gender}
        </Link>
      </div>
      <div className={style.divider}/>
    </>
  )
}
