{
 "cells": [
  {
   "cell_type": "code",
   "execution_count": null,
   "metadata": {},
   "outputs": [],
   "source": [
    "import gym\n",
    "env = gym.make('CartPole-v0')\n",
    "for i_episode in range(20):\n",
    "    observation = env.reset()\n",
    "    for t in range(100):\n",
    "        env.render()\n",
    "        print(observation)\n",
    "        action = env.action_space.sample()\n",
    "        observation, reward, done, info = env.step(action)\n",
    "        if done:\n",
    "            print(\"Episode finished after {} timesteps\".format(t+1))\n",
    "            print((i_episode+1), \"/\", 20)"
   ]
  }
 ],
 "metadata": {
  "kernelspec": {
   "display_name": "Python 3",
   "language": "python",
   "name": "python3"
  },
  "language_info": {
   "name": "python",
   "version": "3.11.2"
  },
  "orig_nbformat": 4,
  "vscode": {
   "interpreter": {
    "hash": "25b0b327ee99f73b7c748fe29ff2a75fc090123f80e65188a14e09cbd4931109"
   }
  }
 },
 "nbformat": 4,
 "nbformat_minor": 2
}
