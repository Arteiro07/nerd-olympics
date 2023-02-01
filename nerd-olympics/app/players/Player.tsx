import React from 'react'
import Image from 'next/image'
import { FcBusinessman } from "react-icons/fc";
import Link from 'next/link'
import { User } from '../types';
import "./player.scss";

export default function Player(user : User ) {
  return (
    <div className='player-card'>
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
  )
}
